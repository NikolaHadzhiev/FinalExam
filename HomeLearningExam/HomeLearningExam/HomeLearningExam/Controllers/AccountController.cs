using Business;
using Bussiness;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLearningExam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly TaskCategoryService _taskCategoryService;
        private readonly StatusService _statusService;
        private readonly RoleService _roleService;

        public AccountController(ILogger<AccountController> logger, TaskCategoryService taskCategoryService, 
            StatusService statusService, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleService roleService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._roleService = roleService;
            _logger = logger;
            this._taskCategoryService = taskCategoryService;
            this._statusService = statusService;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            return await RegisterUser(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await PopulateServices();

            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            return await LoginUser(model, returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


        private async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            IdentityResult result = null;
            ApplicationUser user = null;

            if (ModelState.IsValid)
            {
                if (model.Role == "Client" || model.Role == null)
                {
                    
                    user = new ApplicationUser
                    {
                        UserName = model.Username,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Role = "Administrator",
                    };

                    result = await this.userManager.CreateAsync(user, model.Password);
                }

                if (model.Role == "Administrator")
                {
                    
                    user = new ApplicationUser
                    {
                        
                        UserName = model.Username,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Role = "Administrator",
                        
                    };

                    result = await this.userManager.CreateAsync(user, model.Password);
                }

                if (model.Role == "Housekeeper")
                {

                    user = new ApplicationUser
                    {

                        UserName = model.Username,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Role = "Housekeeper",

                    };

                    result = await this.userManager.CreateAsync(user, model.Password);
                }

                if (result.Succeeded)
                {
                    if (user.Role == "Administrator")
                    {
                        await userManager.AddToRoleAsync(user, "Administrator");

                    }

                    if (user.Role == "Client")
                    {
                        await userManager.AddToRoleAsync(user, "Client");
                    }

                    if (user.Role == "Housekeeper")
                    {
                        await userManager.AddToRoleAsync(user, "Housekeeper");
                    }

                    return RedirectToAction(nameof(Index), "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        private async Task<IActionResult> LoginUser(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await this.signInManager
               .PasswordSignInAsync(model.Username,
                                    model.Password,
                                    false,
                                    false);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction(nameof(Index), "Home");
                }

                ModelState.AddModelError("", "Login attempt failed. Check your credentials");

            }

            return View(model);
        }

        private async System.Threading.Tasks.Task PopulateServices()
        {
            await _roleService.Populate();
            await _statusService.Populate();
            await _taskCategoryService.Populate();
        }
    }
}
