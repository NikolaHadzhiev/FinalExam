using Data;
using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TaskService
    {
        private readonly ApplicationDbContext context;
        public TaskService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<TaskViewModel>> GetAll()
        {
            List<Data.Entities.Task> tasks = await context.Tasks
                .Include(x => x.Location)
                .Include(x => x.TaskCategory)
                .Include(x => x.Status)
                .Include(x => x.User)
                .Include(x => x.AsignedHousekeeper).ToListAsync();
            List<TaskViewModel> tasksViewModel = new List<TaskViewModel>();
            foreach (var task in tasks)
            {
                TaskViewModel viewModel = new TaskViewModel();
                viewModel.Id = task.Id;
                viewModel.Name = task.Name;
                viewModel.Description = task.Description;
                viewModel.Location = new LocationViewModel { Id = task.Location.Id, Name = task.Location.Name, Adress = task.Location.Adress, UserName = task.User.UserName};
                viewModel.DueDate = task.DueDate;
                viewModel.SecondDueDate = task.SecondDueDate;
                viewModel.Budget = task.Budget;
                viewModel.TaskCategory = new TaskCategoryViewModel { Id = task.TaskCategory.Id, Category = task.TaskCategory.Category };
                viewModel.Status = new StatusViewModel { Id = task.Status.Id, TaskStatus = task.Status.TaskStatus };
                viewModel.PhotoPath = task.PhotoPath;
                viewModel.User = new UserViewModel { Id = task.User.Id, FirstName = task.User.FirstName, LastName = task.User.LastName, Username = task.User.UserName};
                viewModel.AsignedHousekeeper = new UserViewModel { Id = task.AsignedHousekeeper.Id, FirstName = task.AsignedHousekeeper.FirstName, LastName = task.AsignedHousekeeper.LastName, Username = task.AsignedHousekeeper.UserName };

                tasksViewModel.Add(viewModel);
            }

            return tasksViewModel;

        }

        public async System.Threading.Tasks.Task Create(TaskViewModel taskViewModel, string userName)
        {
            Data.Entities.Task task = new Data.Entities.Task();
            task.Name = taskViewModel.Name;
            task.Description = taskViewModel.Description;
            task.Location = new Location { Id = taskViewModel.Location.Id, Name = taskViewModel.Location.Name, Adress = taskViewModel.Location.Adress};
            task.DueDate = taskViewModel.DueDate;
            task.SecondDueDate = taskViewModel.SecondDueDate;
            task.Budget = taskViewModel.Budget;
            task.TaskCategory = new TaskCategory { Id = taskViewModel.TaskCategory.Id, Category = taskViewModel.TaskCategory.Category };
            task.Status = new Status { Id = taskViewModel.Status.Id, TaskStatus = taskViewModel.Status.TaskStatus };
            task.PhotoPath = taskViewModel.PhotoPath;
            task.User = new ApplicationUser { Id = taskViewModel.User.Id, FirstName = taskViewModel.User.FirstName, LastName = taskViewModel.User.LastName, UserName = taskViewModel.User.Username };
            task.AsignedHousekeeper = new ApplicationUser { Id = taskViewModel.AsignedHousekeeper.Id, FirstName = taskViewModel.AsignedHousekeeper.FirstName, LastName = taskViewModel.AsignedHousekeeper.LastName, UserName = taskViewModel.AsignedHousekeeper.Username };


            await context.AddAsync(task);
            await context.SaveChangesAsync();
        }


        public async Task<TaskViewModel> GetById(int? id)
        {
            var task = await context.Tasks.
                 Include(x => x.Location)
                .Include(x => x.TaskCategory)
                .Include(x => x.Status)
                .Include(x => x.User)
                .Include(x => x.AsignedHousekeeper).FirstOrDefaultAsync(x => x.Id == id);
            TaskViewModel viewModel = new TaskViewModel();
            viewModel.Id = task.Id;
            viewModel.Name = task.Name;
            viewModel.Description = task.Description;
            viewModel.Location = new LocationViewModel { Id = task.Location.Id, Name = task.Location.Name, Adress = task.Location.Adress, UserName = task.User.UserName };
            viewModel.DueDate = task.DueDate;
            viewModel.SecondDueDate = task.SecondDueDate;
            viewModel.Budget = task.Budget;
            viewModel.TaskCategory = new TaskCategoryViewModel { Id = task.TaskCategory.Id, Category = task.TaskCategory.Category };
            viewModel.Status = new StatusViewModel { Id = task.Status.Id, TaskStatus = task.Status.TaskStatus };
            viewModel.PhotoPath = task.PhotoPath;
            viewModel.User = new UserViewModel { Id = task.User.Id, FirstName = task.User.FirstName, LastName = task.User.LastName, Username = task.User.UserName };
            viewModel.AsignedHousekeeper = new UserViewModel { Id = task.AsignedHousekeeper.Id, FirstName = task.AsignedHousekeeper.FirstName, LastName = task.AsignedHousekeeper.LastName, Username = task.AsignedHousekeeper.UserName };

            return viewModel;
        }

        public async System.Threading.Tasks.Task Update(int id, TaskViewModel taskViewModel)
        {
            Data.Entities.Task task = await context.Tasks
                .Include(x => x.Location)
                .Include(x => x.TaskCategory)
                .Include(x => x.Status)
                .Include(x => x.User)
                .Include(x => x.AsignedHousekeeper).FirstOrDefaultAsync(x => x.Id == id);

            task.Name = taskViewModel.Name;
            task.Description = taskViewModel.Description;
            task.Location = new Location { Id = taskViewModel.Location.Id, Name = taskViewModel.Location.Name, Adress = taskViewModel.Location.Adress };
            task.DueDate = taskViewModel.DueDate;
            task.SecondDueDate = taskViewModel.SecondDueDate;
            task.Budget = taskViewModel.Budget;
            task.TaskCategory = new TaskCategory { Id = taskViewModel.TaskCategory.Id, Category = taskViewModel.TaskCategory.Category };
            task.Status = new Status { Id = taskViewModel.Status.Id, TaskStatus = taskViewModel.Status.TaskStatus };
            task.PhotoPath = taskViewModel.PhotoPath;
            task.User = new ApplicationUser { Id = taskViewModel.User.Id, FirstName = taskViewModel.User.FirstName, LastName = taskViewModel.User.LastName, UserName = taskViewModel.User.Username };
            task.AsignedHousekeeper = new ApplicationUser { Id = taskViewModel.AsignedHousekeeper.Id, FirstName = taskViewModel.AsignedHousekeeper.FirstName, LastName = taskViewModel.AsignedHousekeeper.LastName, UserName = taskViewModel.AsignedHousekeeper.Username };

            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
}
