using MVCBasics.Models;
using System;
using System.Collections.Generic;

namespace MVCBasics.ViewModels
{
    public class PeopleViewModel
    {
        public string SearchedName { get; set; }
        public List<Person> AllPersonsList { get; set; }
        public List<Person> AllPersonsWithSpecificName { get; set; }
    }
}
