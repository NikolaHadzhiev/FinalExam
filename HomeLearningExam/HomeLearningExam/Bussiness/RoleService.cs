using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoleService
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RoleService(ApplicationDbContext context, RoleManager<IdentityRole<int>> roleManager)
        {
            this.context = context;
            this._roleManager = roleManager;
        }


        public async System.Threading.Tasks.Task Populate()
        {
            if (!context.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Administrator"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Client"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Housekeeper"));
            }
        }
        public List<ProjectRole> GetAllRoles()
        {
            var userRoles = new List<ProjectRole>();
            var roles = context.Roles.ToList();
            foreach (var role in roles)
            {
                ProjectRole roleProject = new ProjectRole
                {
                    Name = role.Name
                };

                userRoles.Add(roleProject);
            }

            return userRoles;
        }

    }
}
