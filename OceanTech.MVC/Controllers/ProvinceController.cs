using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Constants;
using BusinessModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OceanTech.MVC.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        // GET: ProvinceController
        public async Task<ActionResult> Index()
        {
            var provinces = await _provinceService.GetProvinces();
            return PartialView("_List", provinces);
        }

        // GET: ProvinceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProvinceController/Create
        public ActionResult Create()
        {
            
            return PartialView("_Create");
        }

        // POST: ProvinceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Province province)
        {
            try
            {
                ModelState.Remove("Districts");
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dữ liệu không hợp lệ", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                // Kiểm tra trùng tên quận/huyện
                var existingDistrict = await _provinceService.GetProvinceByName(province.Name);
                if (existingDistrict != null)
                {
                    return BadRequest(new { message = "Tên tỉnh/thành phố đã tồn tại!" });
                }

                await _provinceService.CreateProvince(province);
                var provinces = await _provinceService.GetProvinces();
                return PartialView("_List", provinces);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống", details = ex.Message });
            }

        }

        // GET: ProvinceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var province = await _provinceService.GetProvinceById(id);
            if (province == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", province);
        }

        // POST: ProvinceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Province province)
        {
            if (id != province.Id)
            {
                return BadRequest();
            }
            ModelState.Remove("Districts");
            if (ModelState.IsValid)
            {
                await _provinceService.UpdateProvince(province);
                //return RedirectToAction(nameof(Index));
            }
            var provinces = await _provinceService.GetProvinces();
            return PartialView("_List", provinces);
        }

        // GET: ProvinceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvinceController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            await _provinceService.DeleteProvince(id);
            var provinces = await _provinceService.GetProvinces();
            return PartialView("_List", provinces);
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var provinces = await _provinceService.GetProvinces();
            return Json(provinces);
        }
    }
}
