using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OceanTech.MVC.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        // GET: DistrictController
        public async Task<ActionResult> Index()
        {
            var districts = await _districtService.GetDistricts();
            return PartialView("_List", districts);
        }

        // GET: DistrictController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DistrictController/Create
        // GET: DistrictController/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: DistrictController/Create
        [HttpPost]
        public async Task<ActionResult> Create(District district)
        {
            try
            {
                ModelState.Remove("Province");
                ModelState.Remove("Wards");
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dữ liệu không hợp lệ", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                await _districtService.CreateDistrict(district);
                var districts = await _districtService.GetDistricts();
                return PartialView("_List", districts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống", details = ex.Message });
            }
        }

        // GET: DistrictController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var district = await _districtService.GetDistrictById(id);
            if (district == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", district);
        }

        // POST: DistrictController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, District district)
        {
            if (id != district.Id)
            {
                return BadRequest();
            }
            ModelState.Remove("Wards");
            ModelState.Remove("Province");

            if (ModelState.IsValid)
            {
                await _districtService.UpdateDistrict(district);
            }
            var districts = await _districtService.GetDistricts();
            return PartialView("_List", districts);
        }

        // POST: DistrictController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _districtService.DeleteDistrict(id);
            var districts = await _districtService.GetDistricts();
            return PartialView("_List", districts);
        }

        // API: Get districts by ProvinceId
        [HttpGet]
        public async Task<JsonResult> GetByProvince(int provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvinceId(provinceId);
            return Json(districts);
        }

        [HttpGet]
        public async Task<JsonResult> GetDistricts(int provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvinceId(provinceId);
            return Json(districts);
        }
    }
}

