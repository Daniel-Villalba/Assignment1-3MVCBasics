using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class CreatePersonViewModel
    {

        [Required(ErrorMessage = "You have to assign a name.")]
        [Display(Name = "Name")]
        public string PersonName { get; set; }


        [Required(ErrorMessage = "You have to assign a phonenumber.")]
        [Display(Name = "Phonenumber")]
        public string Phone { get; set; }

        
        public string City { get; set; }
        [Required]
        public int personCityId { get; set; }

        public Person CreatePerson(ApplicationDbContext db, int cityId)
        {
            Person newPerson = new Person(PersonName, Phone, cityId);
            db.People.Add(newPerson);
            db.SaveChanges();
            
     
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
