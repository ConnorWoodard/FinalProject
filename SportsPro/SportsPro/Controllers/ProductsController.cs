using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using System;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private Repository<Products> productss { get; set; }


        public ProductsController(SportsContext ctx)
        {
            productss = new Repository<Products>(ctx);
        }

        [Route("Products")]
        public IActionResult ProductList()
        {
            var products = productss.List(new QueryOptions<Products>
            {
                OrderBy = p => p.Name
            });
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

            var product = productss.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    productss.Insert(product);
                    TempData["SuccessMessage"] = "Product added successfully!";
                }
                else
                {
                    productss.Update(product);
                    TempData["SuccessMessage"] = "Product updated successfully!";
                }
                productss.Save();
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
            var product = productss.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Products product)
        {
            productss.Delete(product);
            productss.Save();
            TempData["SuccessMessage"] = "Product deleted successfully!";
            return RedirectToAction("ProductList");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
