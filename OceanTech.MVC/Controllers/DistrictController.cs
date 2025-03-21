using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: DistrictController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DistrictController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DistrictController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DistrictController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DistrictController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetDistricts(int provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvinceId(provinceId);
            return Json(districts);
        }
    }
}
