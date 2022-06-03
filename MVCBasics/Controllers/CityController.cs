using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
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

        public IActionResult RemoveCity(int CityId)
        {
            var cityToRemove = _context.Cities.Include("People").Where(p => p.Id == CityId).Single<City>();

            if(cityToRemove != null)
            {
                _context.Cities.Remove(cityToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
