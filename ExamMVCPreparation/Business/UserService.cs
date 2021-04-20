using Data;
using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class UserService
    {
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<UserViewModel> GetAll()
        {
            List<ApplicationUser> allusers = context.Users.ToList();
            List<UserViewModel> viewModels = new List<UserViewModel>();
            foreach (var user in allusers)
            {
                UserViewModel model = new UserViewModel();
                model.Id = user.Id;
                model.Username = user.UserName;
                model.Email = user.Email;
                viewModels.Add(model);
            }
            return viewModels;
        }
    }
}
