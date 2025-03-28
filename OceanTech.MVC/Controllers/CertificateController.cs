using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OceanTech.MVC.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certificateService;
        private readonly IEmployeeService _employeeService;
        public CertificateController(ICertificateService certificateService, IEmployeeService employeeService)
        {
            _certificateService = certificateService;
            _employeeService = employeeService;
        }
        [HttpGet]

        public async Task<IActionResult> Create(int employeeId)
        {
            return PartialView("_CertificateForm", new Certificate { EmployeeId = employeeId });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Certificate certificate)
        {
            // Validate số lượng văn bằng tối đa 3
            var employee = await _employeeService.GetEmployeeById(certificate.EmployeeId);
            if (employee.Certificates.Count >= 3)
            {
                return Json(new { success = false, message = "Mỗi nhân viên chỉ được tối đa 3 văn bằng" });
            }
            ModelState.Remove("Employee");
            if (ModelState.IsValid)
            {
                await _certificateService.CreateCertificate(certificate);
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var certificate = await _certificateService.GetCertificateById(id);
            if (certificate == null)
            {
                return NotFound();
            }
            return PartialView("_CertificateForm", certificate);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Certificate certificate)
        {
            ModelState.Remove("Employee");

            if (!ModelState.IsValid)
            {
                return PartialView("_CertificateForm", certificate);
            }
            await _certificateService.UpdateCertificate(certificate);
            return RedirectToAction("Detail", "Employee", new { id = certificate.EmployeeId });
        }

        

        [HttpPost, ActionName("Delete")]
        public async Task DeleteConfirmed(int id)
        {
            await _certificateService.DeleteCertificate(id);
            //return RedirectToAction("Detail", "Employee", new { id });
        }
    }
}
