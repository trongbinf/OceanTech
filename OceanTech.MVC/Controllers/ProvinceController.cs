using BusinessLogicLayer.Services.Interfaces;
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
            return View();
        }

        // POST: ProvinceController/Create
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

        // GET: ProvinceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvinceController/Edit/5
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

        // GET: ProvinceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvinceController/Delete/5
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
        public async Task<JsonResult> GetAll()
        {
            var provinces = await _provinceService.GetProvinces();
            return Json(provinces);
        }
    }
}
