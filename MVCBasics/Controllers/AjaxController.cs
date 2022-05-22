using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetPersons()
        {
            return PartialView("_PeoplePartialView", Person.AllPersons);
        }
        public ActionResult GetDetails(string index)
        {
            int inputToInt = 0;
            if (int.TryParse(index, out inputToInt))
            {
                if (inputToInt < Person.AllPersons.Count)
                {
                    return PartialView("_DetailsPartialView", Person.AllPersons[inputToInt]);
                }
            }
            return PartialView("_DetailsPartialView", Person.AllPersons);
        }

        public ActionResult RemovePerson(string index)
        {
            int inputToInt = 0;
            if (int.TryParse(index, out inputToInt))
            {
                if (inputToInt < Person.AllPersons.Count)
                {
                    Person.AllPersons.RemoveAt(inputToInt);
                }
            }
            return PartialView("_PeoplePartialView", Person.AllPersons);
        }
    }
}
