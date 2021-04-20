using Business;
using Data;
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
        private readonly ApplicationDbContext _context;
        private readonly UserService userService;

        public AdminController(ApplicationDbContext _context, UserService userService)
        {
            this.userService = userService;
            this._context = _context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {
            List<UserViewModel> users = userService.GetAll();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
