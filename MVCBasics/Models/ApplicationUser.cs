using Microsoft.AspNetCore.Identity;
using System;

namespace MVCBasics.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }    
        public DateTime BirthDate { get; set; }
    }
}
