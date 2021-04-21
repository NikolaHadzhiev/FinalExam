using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RegisterViewModel
    {

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        //[Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Confirm Password does not match Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string Role { get; set; }

        public IFormFile Photo { get; set; }
    }
}
