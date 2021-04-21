using Business;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMVCPreparation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleService roleService;

        public readonly IHostingEnvironment HostingEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleService roleService, IHostingEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleService = roleService;
            this.HostingEnvironment = hostingEnvironment;
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
        public IActionResult Login()
        {
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
                string uniqueFileName = null;
                if (model.Role == "User" || model.Role == null)
                {
                    if (model.Photo != null)
                    {
                        string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        if (!uniqueFileName.Contains(".jpg") || !uniqueFileName.Contains(".png"))
                        {
                            uniqueFileName = null;
                        }
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                    user = new ApplicationUser
                    {
                        Email = model.Email,
                        UserName = model.Username,
                        FirstName = model.FirstName,
                        BirthDate = model.BirthDate,
                        Role = "User",
                        PhotoPath = uniqueFileName
                    };

                    result = await this.userManager.CreateAsync(user, model.Password);
                }

                if (model.Role == "Admin")
                {
                    if (model.Photo != null)
                    {
                        string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                    user = new ApplicationUser
                    {
                        Email = model.Email,
                        UserName = model.Username,
                        FirstName = model.FirstName,
                        Role = "Admin",
                        PhotoPath = uniqueFileName
                    };

                    result = await this.userManager.CreateAsync(user, model.Password);
                }

                if (result.Succeeded)
                {

                    //if (user.UserName.Contains("admin"))
                    //{
                    //    await userManager.AddToRoleAsync(user, "Admin");
                    //}
                    //else
                    //{
                    //    await userManager.AddToRoleAsync(user, "User");
                    //}
                    if (user.Role == "Admin")
                    {
                        await userManager.AddToRoleAsync(user, "Admin");

                    }

                    if (user.Role == "User")
                    {
                        await userManager.AddToRoleAsync(user, "User");
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
                                    model.RememberMe,
                                    false);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction(nameof(Index), "Home");
                }

                ModelState.AddModelError("", "Login attempt failed");

            }

            return View(model);
        }
    }
}
