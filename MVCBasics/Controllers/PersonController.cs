using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCBasics.Controllers
{
    public class PersonController : Controller
    {
        private static PeopleViewModel peopleViewModel;
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;

            if(peopleViewModel == null)
            {
                peopleViewModel = new PeopleViewModel();
                peopleViewModel.AllPersonsList = _context.People.ToList();
            }
        }
        public IActionResult Persons()
        {
            peopleViewModel = new PeopleViewModel();
            peopleViewModel.AllPersonsList = _context.People.Include("PersonLanguages.Language").ToList();
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "Name");

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Persons(CreatePersonViewModel createPersonViewModel, string searchedName, int CityId)
        {
            if (searchedName != null)
            {

                peopleViewModel = new PeopleViewModel();

                Person.ReturnByNameOrCity(searchedName, _context);

                peopleViewModel.AllPersonsWithSpecificName = Person.byNameList;

                ViewBag.Cities = new SelectList(_context.Cities, "Id", "Name");

                return View(peopleViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    createPersonViewModel.CreatePerson(_context, CityId);
                   
                    return RedirectToAction("Persons");
                }
                else
                {
                    return RedirectToAction("Persons");
                    
                }
            }
        }

        public IActionResult Delete(int id)
        {
            Person.DeletePerson(id, _context);

            return RedirectToAction("Persons");
        }
    }
}
