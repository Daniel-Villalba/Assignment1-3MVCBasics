using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class CreatePersonViewModel
    {
        /*Antar att detta måste ändras då det kan finnas fler poster lagrade i databasen vid nästa körning
        av programmet*/
        private static int tempId = 4; //Denna siffra måste vara dynamisk!
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to assign a name.")]
        [Display(Name = "Name")]
        public string PersonName { get; set; }


        [Required(ErrorMessage = "You have to assign a phonenumber.")]
        [Display(Name = "Phonenumber")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "You have to assign a city.")]
        [Display(Name = "City")]
        public string City { get; set; }

        public Person CreatePerson(string name, string phone, string city)
        {
            tempId = Person.NextId(tempId);

            Person newPerson = new Person()
            {
                PersonId = tempId,
                Name = name,
                PhoneNumber = phone,
                City = city
            };

            return newPerson;
        }

        public Person CreatePerson(ApplicationDbContext db)
        {
            Person newPerson = new Person(PersonName, Phone, City);
            db.People.Add(newPerson);
            db.SaveChanges();
        
            return newPerson;    
        }
    }
}
