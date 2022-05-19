using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using System;
using System.Collections.Generic;

namespace MVCBasics.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Persons()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.AllPersonsList = Person.AllPersons;

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Persons(CreatePersonViewModel createPersonViewModel, string searchedName)
        {
            if (searchedName != null)
            {

                PeopleViewModel peopleViewModel = new PeopleViewModel();

                Person.ReturnByNameOrCity(searchedName);

                peopleViewModel.AllPersonsWithSpecificName = Person.byNameList;

                return View(peopleViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    CreatePersonViewModel createPerson = new CreatePersonViewModel();
                    Person returnedPerson = createPerson.CreatePerson(createPersonViewModel.PersonName, createPersonViewModel.Phone, createPersonViewModel.City);

                    Person.AllPersons.Add(returnedPerson);
                    return RedirectToAction("Persons");
                }
                else
                {
                    PeopleViewModel peopleViewModel = new PeopleViewModel();
                    peopleViewModel.AllPersonsList = Person.AllPersons;

                    return View(peopleViewModel);
                }
            }
        }

        public IActionResult Delete(int id)
        {
            Person.DeletePerson(id);

            return RedirectToAction("Persons");
        }
    }
}
