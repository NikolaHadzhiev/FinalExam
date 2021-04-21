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

        public ApplicationUser Edit(int? id, UserViewModel viewModel)
        {
            ApplicationUser returnUser = null;

            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }
            try
            {
                returnUser = this.context.Users.FirstOrDefault(x => x.Id == id);
                returnUser.UserName = viewModel.Username;
                returnUser.Email = viewModel.Email;

            }
            catch (Exception)
            {

                var user = this.context.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    throw new ArgumentNullException("Id must not be null");
                    //throw new EntityNotFoundException("");
                }
                else
                {
                    throw new Exception("Some Reason");
                }
            }
            context.SaveChanges();
            return returnUser;
        }
        private ApplicationUser OfUserDto(UserViewModel viewModel)
        {
            return new ApplicationUser()
            {
                Id = viewModel.Id,
                FirstName = viewModel.Username,
                UserName = viewModel.Username,
                Email = viewModel.Email
            };
        }

        public ApplicationUser GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }
            return user;
        }

        public void Delete(int? id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            context.Remove(user);
            context.SaveChanges();

        }
    }
}