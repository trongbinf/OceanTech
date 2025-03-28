using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OceanTech.MVC.Controllers
{
    public class WardController : Controller
    {
        private readonly IWardService _wardService;
        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }
        // GET: WardController
        public async Task<ActionResult> Index()
        {
            var wards = await _wardService.GetWards();
            return PartialView("_List", wards);
        }

        // GET: WardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WardController/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: WardController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Ward ward)
        {
            try
            {
                ModelState.Remove("District");
                ModelState.Remove("Employees");
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dữ liệu không hợp lệ", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                await _wardService.CreateWard(ward);
                var wards = await _wardService.GetWards();
                return PartialView("_List", wards);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống", details = ex.Message });
            }
        }

        // GET: WardController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var ward = await  _wardService.GetWardById(id);
            if (ward == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", ward);
        }

        // POST: WardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Ward ward)
        {
            if(id != ward.Id)
            {
                return BadRequest();
            }
            ModelState.Remove("District");
            ModelState.Remove("Employees");
            if(ModelState.IsValid)
            {
                await _wardService.UpdateWard(ward);
            }
            var wards = await _wardService.GetWards();
            return PartialView("_List", wards);
        }

        // GET: WardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WardController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _wardService.DeleteWard(id);
            var wards = await _wardService.GetWards();
            return PartialView("_List", wards);
        }
        [HttpGet]
        public async Task<JsonResult> GetWards(int districtId)
        {
            var wards = await _wardService.GetWardsByDistrictId(districtId);
            return Json(wards);
        }
    }
}
