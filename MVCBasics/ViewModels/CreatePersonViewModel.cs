using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class CreatePersonViewModel
    {
        private static int tempId = 3;
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
    }
}
