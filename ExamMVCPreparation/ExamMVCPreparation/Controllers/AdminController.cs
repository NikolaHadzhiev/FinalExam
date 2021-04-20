using Business;
using Data;
using Data.Models;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRole role)
        {
            var result = await roleManager.CreateAsync(new IdentityRole<int>(role.RoleName));
            return View();
        }
        public IActionResult AllUsers()
        {
            List<UserViewModel> users = userService.GetAll();
            return View(users);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
