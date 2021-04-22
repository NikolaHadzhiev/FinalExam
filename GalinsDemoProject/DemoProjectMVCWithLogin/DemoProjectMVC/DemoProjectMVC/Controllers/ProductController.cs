using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Business;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DemoProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductService productService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ProductController(AppDbContext context, ProductService productService , SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.productService = productService;
            this.signInManager = signInManager;
        }

   
        public IActionResult Index()
        {
            if (this.User != null && this.signInManager.IsSignedIn(this.User))
            {
                List<Product> products = this.productService.GetAll();

                return View(products);
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Details(int? id)
        {
            Product product = this.productService.GetById(id);

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                this.productService.Create(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            Product product = this.productService.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDto product)
        {
            if (ModelState.IsValid)
            {
                this.productService.Edit(id, product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            Product product = this.productService.GetById(id);

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            this.productService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
