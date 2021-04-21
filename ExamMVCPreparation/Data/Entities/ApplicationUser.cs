using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = "";
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime BirthDate { get; set; }
        public string City { get; set; } = "";

        public string Role { get; set; } = "User";

        public string PhotoPath { get; set; }

    }
}
