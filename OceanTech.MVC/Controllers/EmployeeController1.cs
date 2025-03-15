using Microsoft.AspNetCore.Mvc;

namespace OceanTech.MVC.Controllers
{
    public class EmployeeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
