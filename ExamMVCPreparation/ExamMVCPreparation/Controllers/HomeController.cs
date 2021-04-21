using Business;
using Data.Entities;
using ExamMVCPreparation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ExamMVCPreparation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        private readonly RoleService roleService;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleService roleService, RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.roleService = roleService;

        }

        public async Task<IActionResult> Index()
        {
            if (!roleService.RoleExists())
            {
                var user = await _roleManager.CreateAsync(new IdentityRole<int>("User"));
                var admin = await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
