using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class ProductsController : Controller
    {
        private SportsContext Context { get; set; }

        public ProductsController(SportsContext ctx)
        {
            Context = ctx;
        }

        [Route("Products")]
        public IActionResult ProductList()
        {
            var products = Context.Products.OrderBy(p => p.Name).ToList();
            return View(products);
        }

        [Route("Products/AddProduct")]
        public IActionResult AddProduct()
        {
            ViewBag.Action = "Add Product";

            var product = new Products()
            {
                ReleaseDate = DateTime.Now
            };

            return View("EditProduct", product);
        }

        [HttpGet]
        [Route("Product/Edit/{id}/{Slug}")]
        public IActionResult EditProduct(int id)
        {
            ViewBag.Action = "Edit Product";

            var product = Context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct2(Products product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    Context.Products.Add(product);
                    TempData["SuccessMessage"] = "Product added successfully!";
                }
                else
                {
                    Context.Products.Update(product);
                    TempData["SuccessMessage"] = "Product updated successfully!";
                }
                Context.SaveChanges();
                return RedirectToAction("ProductList", "Products");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add Product" : "Edit Product";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Products product)
        {
            Context.Products.Remove(product);
            Context.SaveChanges();
            TempData["SuccessMessage"] = "Product deleted successfully!";
            return RedirectToAction("ProductList");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
