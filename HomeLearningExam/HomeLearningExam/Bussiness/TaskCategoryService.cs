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
    public class TaskCategoryService
    {
        private readonly ApplicationDbContext context;
        public TaskCategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async System.Threading.Tasks.Task Populate()
        {
            if (!context.TaskCategories.Any())
            {
                await context.TaskCategories.AddAsync(new TaskCategory { Category = "почистване и дезинфекция"});
                await context.TaskCategories.AddAsync(new TaskCategory { Category = "грижа за домашни любимци и растения" });
                await context.TaskCategories.AddAsync(new TaskCategory { Category = "грижа за дете" });
                await context.TaskCategories.AddAsync(new TaskCategory { Category = "грижа за възрастен човек"});

               await context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskCategoryViewModel>> GetAll()
        {
            List<TaskCategory> taskCategories = await context.TaskCategories.ToListAsync();
            List<TaskCategoryViewModel> taskCategoryViewModel = new List<TaskCategoryViewModel>();
            foreach (var status in taskCategories)
            {
                TaskCategoryViewModel viewModel = new TaskCategoryViewModel();
                viewModel.Id = status.Id;
                viewModel.Category = status.Category;
               

                taskCategoryViewModel.Add(viewModel);
            }

            return taskCategoryViewModel;

        }

        public async System.Threading.Tasks.Task Create(TaskCategoryViewModel taskCategoryViewModel)
        {
            TaskCategory taskCategory = new TaskCategory();
            taskCategory.Category = taskCategoryViewModel.Category;
     
            context.Add(taskCategory);
            await context.SaveChangesAsync();
        }


        public async Task<TaskCategoryViewModel> GetById(int? id)
        {
            var taskCategory = await context.TaskCategories.FirstOrDefaultAsync(x => x.Id == id);
            TaskCategoryViewModel viewModel = new TaskCategoryViewModel();
            viewModel.Id = taskCategory.Id;
            viewModel.Category = taskCategory.Category;
          
            return viewModel;
        }

        public async System.Threading.Tasks.Task Edit(int id, TaskCategoryViewModel taskCategoryViewModel)
        {
            TaskCategory taskCategory = await context.TaskCategories.FirstOrDefaultAsync(x => x.Id == id);
            taskCategory.Category = taskCategoryViewModel.Category;
           
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var taskCategory = await context.TaskCategories.FirstOrDefaultAsync(x => x.Id == id);
            context.TaskCategories.Remove(taskCategory);
            await context.SaveChangesAsync();
        }
    }
}
