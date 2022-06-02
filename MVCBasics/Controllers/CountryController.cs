using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using System.Linq;

namespace MVCBasics.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listOfCountries = _context.Countries.Include("Cities").ToList();
            return View(listOfCountries);
        }
        public IActionResult CreateCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Remove(int id)
        {
            var countryToRemove = _context.Countries.Find(id);

            _context.Countries.Remove(countryToRemove);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
