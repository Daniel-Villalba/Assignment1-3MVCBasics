using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public string City { get; set; } 
        

       public City PersonCity { get; set; }
        [ForeignKey("PersonCityId")]
        public int PersonCityId { get; set; }

        public List<Language> Languages { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set; }

        public Person(string name, string phoneNumber, int cityId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            PersonCityId = cityId;
        }

        public Person(int id, string name, string phoneNumber, int cityId)
        {
            PersonId = id;
            Name = name;
            PhoneNumber = phoneNumber;
            PersonCityId = cityId;
        }
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

            foreach (Person personWithName in db.People.Include("PersonCity").ToList())
            {
                if (personWithName.Name.Contains(name, StringComparison.OrdinalIgnoreCase) || personWithName.PersonCity.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
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
