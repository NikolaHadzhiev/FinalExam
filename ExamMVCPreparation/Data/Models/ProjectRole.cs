using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProjectRole : IdentityRole<int>
    {
        public string Name { get; set; }

       // public List<> MyProperty { get; set; }
    }
}
