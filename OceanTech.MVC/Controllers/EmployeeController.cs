using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Constants;
using BusinessModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;

namespace OceanTech.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;

        public EmployeeController(IEmployeeService employeeService, IProvinceService provinceService, IDistrictService districtService, IWardService wardService)
        {
            _employeeService = employeeService;
            _districtService = districtService;
            _provinceService = provinceService;
            _wardService = wardService;
        }


        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetEmployees();
            return PartialView("_List", employees);
        }

        public IActionResult Create()
        {
            ViewBag.EthnicGroups = EmployeeConsts.EthnicGroups;
            ViewBag.Jobs = EmployeeConsts.Jobs;
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {

            ModelState.Remove("Certificates");
            ModelState.Remove("Ward");

            var employeeExist = await _employeeService.GetEmployeeByIdentityCard(employee.IdentityCard);
            if (ModelState.IsValid && employeeExist == null)
            {
                await _employeeService.CreateEmployee(employee);
            }
            var employees = await _employeeService.GetEmployees();

            return PartialView("_List", employees);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.EthnicGroups = EmployeeConsts.EthnicGroups;
            ViewBag.Jobs = EmployeeConsts.Jobs;
            return PartialView("_Edit", employee);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            ModelState.Remove("Ward");
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployee(employee);
                //return RedirectToAction(nameof(Index));
            }
            var employees = await _employeeService.GetEmployees();
            return PartialView("_List", employees);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteEmployee(id);
            var employees = await _employeeService.GetEmployees();
            return PartialView("_List", employees);
        }
        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File không hợp lệ!");
            }
            List<string> errors = new List<string>();
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        List<Employee> employees = new List<Employee>();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var dob = worksheet.Cells[row, 2].Value;
                            var employee = new Employee
                            {
                                FullName = worksheet.Cells[row, 1].Text.Trim(),
                                DateOfBirth = GetDateFromCell(dob), 
                                EthnicGroup = worksheet.Cells[row, 3].Text.Trim(),
                                Job = worksheet.Cells[row, 4].Text.Trim(),
                                PhoneNumber = worksheet.Cells[row, 5].Text.Trim(),
                                IdentityCard = worksheet.Cells[row, 6].Text.Trim(),
                                Address = worksheet.Cells[row, 10].Text.Trim(),
                            };
                            var employeeExist = await _employeeService.GetEmployeeByIdentityCard(employee.IdentityCard);
                            if (employeeExist != null)
                            {
                                //lỗi trùng số CMND
                                errors.Add($"Lỗi tại dòng {row}: Số CMND '{employee.IdentityCard}' đã tồn tại.");
                                continue;
                            }

                            string wardName = worksheet.Cells[row, 7].Text.Trim();
                            string districtName = worksheet.Cells[row, 8].Text.Trim();
                            string provinceName = worksheet.Cells[row, 9].Text.Trim();

                            var province = await _provinceService.GetProvinceByName(provinceName);
                            if (province == null)
                            {
                                //lỗi tỉnh không tồn tại
                                errors.Add($"Lỗi tại dòng {row}: Tỉnh '{provinceName}' không tồn tại.");
                                continue;
                            }
                            var districtInProvince = await _districtService.GetDistrictsByProvinceId(province.Id);
                            var district = await _districtService.GetDistrictByName(districtName);
                            if (district == null || !districtInProvince.ToList().Contains(district))
                            {
                                //lỗi huyện không thuộc tỉnh
                                // errors.Add($"Lỗi tại dòng {row}: Huyện '{districtName}' không thuộc tỉnh '{provinceName}'.");
                                continue;
                            }

                            var wardInDistrict = await _wardService.GetWardsByDistrictId(district.Id);
                            var ward = await _wardService.GetWardByName(wardName);
                            if (ward == null || !wardInDistrict.Contains(ward))
                            {
                                //lỗi xã không thuộc huyện
                                errors.Add($"Lỗi tại dòng {row}: Xã '{wardName}' không thuộc huyện '{districtName}'.");
                                continue;
                            }
                            var validationResults = new List<ValidationResult>();
                            var validationContext = new ValidationContext(employee);
                            if (!Validator.TryValidateObject(employee, validationContext, validationResults, true))
                            {
                                foreach (var validationResult in validationResults)
                                {
                                    errors.Add($"Lỗi tại dòng {row}: {validationResult.ErrorMessage}");
                                }
                                continue;
                            }

                            employee.WardId = ward.Id;
                            employees.Add(employee);
                        }
                        if (errors.Any())
                        {
                            return BadRequest(new { message = errors[0] });
                        }

                        await _employeeService.AddRangeEmployee(employees);


                        return Ok(new { message = "Import thành công!" });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi khi import: " + ex.Message);
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return PartialView("_Detail", employee);
        }
        public DateOnly GetDateFromCell(object cellValue)
        {
            if (cellValue == null)
                throw new ArgumentNullException(nameof(cellValue));

            if (cellValue is DateTime dateTime)
            {
                return DateOnly.FromDateTime(dateTime);
            }

            if (DateTime.TryParse(cellValue.ToString(), out DateTime parsedDate))
            {
                return DateOnly.FromDateTime(parsedDate);
            }

            throw new FormatException("Could not convert cell value to DateOnly");
        }
    }
}
