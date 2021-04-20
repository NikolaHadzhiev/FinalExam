using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProjectRole : IdentityRole<int>
    {
        public string RoleName { get; set; }
    }
}
