using Bussines.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMVCPreparation.Controllers
{
    public class CataloguesController : Controller
    {
        private readonly CataloguesService catalogueService;
        public CataloguesController(CataloguesService catalogueService)
        {

            this.catalogueService = catalogueService;
        }
        public IActionResult MyCatalogues()
        {
            var currentUser = HttpContext.User;
            string username = currentUser.Identity.Name;
            List<CataloguesViewModel> catalogues = catalogueService.GetMyCatalogues(username);
            return View(catalogues);
        }
    }
}
