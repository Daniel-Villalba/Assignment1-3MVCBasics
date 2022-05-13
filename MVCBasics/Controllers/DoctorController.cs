using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetTemperature()
        {
            ViewBag.Message = DoctorModel.WriteMessage();
            return View();
        }
        [HttpPost]

        public IActionResult GetTemperature(int temperature)
        {
            ViewBag.Message = DoctorModel.CheckTemp(temperature);
            return View();
        }
    }
}
