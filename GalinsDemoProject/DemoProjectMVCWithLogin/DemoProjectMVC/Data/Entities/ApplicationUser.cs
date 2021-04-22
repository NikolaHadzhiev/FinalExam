using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = "";
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string City { get; set; } = "";

    }
}