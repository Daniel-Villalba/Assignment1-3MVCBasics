using Microsoft.AspNetCore.Mvc;
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
        /*public IActionResult Index()
        {
            return View();
        } */
        public IActionResult Persons()
        {
            peopleViewModel = new PeopleViewModel();
            peopleViewModel.AllPersonsList = _context.People.ToList();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Persons(CreatePersonViewModel createPersonViewModel, string searchedName)
        {
            if (searchedName != null)
            {

                peopleViewModel = new PeopleViewModel();

                Person.ReturnByNameOrCity(searchedName, _context);

                peopleViewModel.AllPersonsWithSpecificName = Person.byNameList;

                return View(peopleViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    createPersonViewModel.CreatePerson(_context);
                    /*CreatePersonViewModel createPerson = new CreatePersonViewModel();
                    Person returnedPerson = createPerson.CreatePerson(createPersonViewModel.PersonName, createPersonViewModel.Phone, createPersonViewModel.City);

                    Person.AllPersons.Add(returnedPerson);*/
                    return RedirectToAction("Persons");
                }
                else
                {
                    return RedirectToAction("Persons");
                    /* peopleViewModel = new PeopleViewModel();
                     peopleViewModel.AllPersonsList = Person.AllPersons;

                     return View(peopleViewModel);*/
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
