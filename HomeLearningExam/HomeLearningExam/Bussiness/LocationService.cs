using Data;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class LocationService
    {
        private readonly ApplicationDbContext context;

        public LocationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<LocationViewModel>> GetMyLocations(string userName)
        {
            List<Location> locations = await context.Locations.Where(x => x.User.UserName == userName).ToListAsync();
            List<LocationViewModel> locationsViewModel = new List<LocationViewModel>();
            foreach (var location in locations)
            {
                LocationViewModel viewModel = new LocationViewModel();
                viewModel.Id = location.Id;
                viewModel.Name = location.Name;
                viewModel.Adress = location.Adress;
                viewModel.UserName = userName;

                locationsViewModel.Add(viewModel);
            }

            return locationsViewModel;

        }

        public async Task<List<LocationViewModel>> GetAllLocations()
        {
            List<Location> locations = await context.Locations.Include(x => x.User).ToListAsync();
            List<LocationViewModel> locationsViewModel = new List<LocationViewModel>();
            foreach (var location in locations)
            {
                LocationViewModel viewModel = new LocationViewModel();
                viewModel.Id = location.Id;
                viewModel.Name = location.Name;
                viewModel.Adress = location.Adress;
                viewModel.UserName = location.User.UserName;

                locationsViewModel.Add(viewModel);
            }

            return locationsViewModel;

        }

        public async System.Threading.Tasks.Task Create(LocationViewModel locationViewModel, string userName)
        {
            Location location = new Location();
            location.Name = locationViewModel.Name;
            location.Adress = locationViewModel.Adress;
            location.User = context.Users.FirstOrDefault(x => userName == x.UserName);
            context.Add(location);
            await context.SaveChangesAsync();
        }

       
        public async Task<LocationViewModel> GetById(int? id)
        {
            var location = await context.Locations.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            LocationViewModel viewModel = new LocationViewModel();
            viewModel.Id = location.Id;
            viewModel.Name = location.Name;
            viewModel.Adress = location.Adress;
            return viewModel;
        }

        public async System.Threading.Tasks.Task Edit(int id, LocationViewModel locationViewModel)
        {
            Location location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            location.Name = locationViewModel.Name;
            location.Adress = locationViewModel.Adress;
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            context.Locations.Remove(location);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<bool> LocationIsAssignedToTask(int id)
        {
            List<Data.Entities.Task> tasks = await context.Tasks.Include(x => x.Location).ToListAsync();
            var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            List<int> locationsIds = new List<int>();

            foreach (var task in tasks)
            {
                locationsIds.Add(task.Location.Id);
            }

            if (locationsIds.Contains(id))
            {
                return true;
            }

            return false;
        }
    }
}
