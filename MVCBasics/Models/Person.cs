using System;
using System.Collections.Generic;

namespace MVCBasics.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public static List<Person> AllPersons = new List<Person>
        {
                new Person { PersonId = 1, Name = "Adam Andersson", PhoneNumber = "031445511", City = "Trollhättan" },
                new Person { PersonId = 2, Name = "Bengt Bengtsson", PhoneNumber = "031548422", City = "Göteborg" },
                new Person { PersonId = 3, Name = "Erik Eriksson", PhoneNumber = "031443433", City = "Stockholm" }
        };

        public static List<Person> byNameList = new List<Person>();

        public static int NextId(int id)
        {
            return ++id;
        }

        public static void ReturnByNameOrCity(string name)
        {
            byNameList.Clear();

            foreach (Person personWithName in AllPersons)
            {
                if (personWithName.Name.Contains(name, StringComparison.OrdinalIgnoreCase) || personWithName.City.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    byNameList.Add(personWithName);
                }

         
            }
        }

        public static void DeletePerson(int id)
        {
            foreach (Person person in AllPersons)
            {
                if (person.PersonId == id)
                {
                    AllPersons.Remove(person);
                    break;
                }
            }
        }
    }
}
