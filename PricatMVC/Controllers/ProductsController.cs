using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PricatMVC.Data;
using PricatMVC.Models;

namespace PricatMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PricatMVCContext _context;
        private static List<Product> productList = null!;
        private static int numProducts;
        public ProductsController()
        {
            // Mock Student List
            if (productList is null)
            {
                productList = new List<Product>()
        {
            new Product{CategoryId = 1, Description = "Arroz", EanCode = "7707548516286", Id = 1, Price = 500.0, Unit = "Lb"},
            new Product{CategoryId = 1, Description = "Papa", EanCode = "7707548941507", Id = 2, Price = 1500.0, Unit = "Lb"},
            new Product{CategoryId = 2, Description = "Cocacola", EanCode = "7707548160274", Id = 3, Price = 2500.0, Unit = "Lb"},
        };

                numProducts = productList.Count;
            }
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(productList);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var productFound = productList.FirstOrDefault(u => u.Id == id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var product = new Product();
            product.Id = 4;
            return View(product);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Id = ++numProducts;
                    productList.Add(product);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var productFound = productList.FirstOrDefault(u => u.Id == id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productFound = productList.FirstOrDefault(u => u.Id == product.Id);

                    if (productFound == null)
                    {
                        return View();
                    }

                    productFound.Description = product.Description;
                    productFound.EanCode = product.EanCode;
                    productFound.Price = product.Price;
                    productFound.Unit = product.Unit;

                    return RedirectToAction(nameof(Index));
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var productFound = productList.FirstOrDefault(u => u.Id == id);

            if (productFound == null)
            {
                return NotFound();
            }

            return View(productFound);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                var productFound = productList.FirstOrDefault(u => u.Id == product.Id);

                if (productFound == null)
                {
                    return View();
                }


                productList.Remove(productFound);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
