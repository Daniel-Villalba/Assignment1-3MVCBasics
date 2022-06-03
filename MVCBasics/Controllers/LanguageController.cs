using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using System.Linq;
using MVCBasics.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCBasics.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listOfLanguages = _context.Languages.Include("PersonLanguages.Person").ToList();
            return View(listOfLanguages);
        }

        public IActionResult CreateLanguage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLanguage(Language language)
        {

            _context.Languages.Add(language);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult RemoveLanguage(int languageId)
        {
            var LanguageToRemove = _context.Languages.Where(l => l.LanguageId == languageId).Single();

            if (LanguageToRemove != null)
            {
                _context.Languages.Remove(LanguageToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AssignLanguage()
        {
            ViewBag.People = new SelectList(_context.People, "PersonId", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "LanguageId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AssignLanguage(int personId, int languageId)
        {
            var knownlanguage = _context.PersonLanguages.Find(personId, languageId);
            if (knownlanguage == null)
            {
                _context.PersonLanguages.Add(new PersonLanguage { PersonId = personId, LanguageId = languageId });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
