using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasics.Models
{
    public class Country //Person cinema
    {
        

        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        [ForeignKey("CitiesId")]
        public int? CitiesId { get; set; }
        public Country()
        {

        }
        public Country(int id, string name, int citiesID)
        {
            Id = id;
            Name = name;
        }
    }
}
