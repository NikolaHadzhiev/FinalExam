using Data;
using Data.Models;
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
        public RoleService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool RoleExists(string name)
        {
            return context.Roles.Any(e => e.Name == name);
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
