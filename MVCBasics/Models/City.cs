using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Models
{
    public class City //Car Movies
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public Country Country { get; set; }
        public int? CountryId { get; set; }

    }
}
