using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVCBasics.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }

        public Person(string name, string phoneNumber, string city)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.City = city;   
        }
        public Person()
        {

        }

        public static List<Person> AllPersons = new List<Person>();
        
       

        public static List<Person> byNameList = new List<Person>();

        public static int NextId(int id)
        {
            return ++id;
        }

        public static void ReturnByNameOrCity(string name, ApplicationDbContext db)
        {
            byNameList.Clear();

            foreach (Person personWithName in db.People.ToList())
            {
                if (personWithName.Name.Contains(name, StringComparison.OrdinalIgnoreCase) || personWithName.City.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    byNameList.Add(personWithName);
                }

         
            }
        }

        public static void DeletePerson(int id, ApplicationDbContext db)
        {
            foreach (Person person in db.People.ToList())
            {
                if (person.PersonId == id)
                {
                    db.People.Remove(person);
                    db.SaveChanges();
                    break;
                }
            }
        }
    }
}
