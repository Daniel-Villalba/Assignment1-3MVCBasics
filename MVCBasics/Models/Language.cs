using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
