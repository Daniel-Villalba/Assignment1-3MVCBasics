using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using System.Linq;

namespace MVCBasics.Controllers
{
    public class CityController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listOfCities = _context.Cities.Include("People").Include("Country").ToList();
            return View(listOfCities);
        }
        public IActionResult CreateCity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Remove(int id)
        {
            var cityToRemove = _context.Cities.Find(id);

            _context.Cities.Remove(cityToRemove);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
