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
    public class StatusService
    {

        private readonly ApplicationDbContext context;
        public StatusService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async System.Threading.Tasks.Task Populate()
        {
            if (!context.Statuses.Any())
            {
                await context.Statuses.AddAsync(new Status { TaskStatus = "Чакаща" });
                await context.Statuses.AddAsync(new Status { TaskStatus = "Назначена на домашен помощник" });
                await context.Statuses.AddAsync(new Status { TaskStatus = "За преглед" });
                await context.Statuses.AddAsync(new Status { TaskStatus = "Изпълнена" });
                await context.Statuses.AddAsync(new Status { TaskStatus = "Отказана" });

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<StatusViewModel>> GetAll()
        {
            List<Status> statuses = await context.Statuses.ToListAsync();
            List<StatusViewModel> statusViewModel = new List<StatusViewModel>();
            foreach (var status in statuses)
            {
                StatusViewModel viewModel = new StatusViewModel();
                viewModel.Id = status.Id;
                viewModel.TaskStatus = status.TaskStatus;
                

                statusViewModel.Add(viewModel);
            }

            return statusViewModel;

        }

        public async System.Threading.Tasks.Task Create(StatusViewModel statusViewModel)
        {
            Status status = new Status();
            status.TaskStatus = statusViewModel.TaskStatus;
            
            context.Add(status);
            await context.SaveChangesAsync();
        }


        public async Task<StatusViewModel> GetById(int? id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            StatusViewModel viewModel = new StatusViewModel();
            viewModel.Id = status.Id;
            viewModel.TaskStatus = status.TaskStatus;
            return viewModel;
        }

        public async System.Threading.Tasks.Task Edit(int id, StatusViewModel statusViewModel)
        {
            Status status = await context.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            status.TaskStatus = statusViewModel.TaskStatus;
            status.TaskStatus = statusViewModel.TaskStatus;
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            context.Statuses.Remove(status);
            await context.SaveChangesAsync();
        }
    }
}
