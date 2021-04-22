using Business;
using Data;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamMVCPreparation.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly ApplicationDbContext _context;
        private readonly UserService userService;
        public AdminController(RoleManager<IdentityRole<int>> roleManager, ApplicationDbContext _context, UserService userService)
        {
            this.userService = userService;
            this.roleManager = roleManager;
            this._context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectRole role)
        {
            var roleExists = await roleManager.RoleExistsAsync(role.Name);
            if (!roleExists)
            {
                var result = await roleManager.CreateAsync(new IdentityRole<int>(role.Name));
            }
            return View(role);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AllUsers()
        {
            List<UserViewModel> users = userService.GetAll();
            return View(users);
        }
        [HttpPost]
        public IActionResult Edit(int id, UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                userService.Edit(id, userModel);
                return RedirectToAction(nameof(AllUsers));
            }

            return View(userModel);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ApplicationUser user = userService.GetById(id);
            return View(user);
        }
        public IActionResult Details(int? id)
        {
            ApplicationUser user = userService.GetById(id);
            return View(user);
        }
        public IActionResult Delete(int? id)
        {
            ApplicationUser user = userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return RedirectToAction(nameof(AllUsers));
        }

        [HttpGet]
        public IActionResult AllUsers(string Empsearch)
        {
            ViewData["GetDetails"] = Empsearch;
            return View(userService.SearchUser(Empsearch));
        }

    }
}
