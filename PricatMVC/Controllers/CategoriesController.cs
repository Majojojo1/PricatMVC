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
    public class CategoriesController : Controller
    {
        private readonly PricatMVCContext _context;
        private static List<Category> categoryList = null!;
        private static int numCategories;
        public CategoriesController()
        {
            // Mock Categoty List
            if (categoryList is null)
            {
                categoryList = new List<Category>()
        {
            new Category{Description="Alimentos",Id=1},
            new Category{Description="Bebidas",Id=2},
            new Category{Description="Productos de Aseo",Id=3},
        };

                numCategories = categoryList.Count;
            }
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            return View(categoryList);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var categoryFound = categoryList.FirstOrDefault(u => u.Id == id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            var category = new Category();
            category.Id = 4;
            return View(category);
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.Id = ++numCategories;
                    categoryList.Add(category);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var categoryFound = categoryList.FirstOrDefault(u => u.Id == id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryFound = categoryList.FirstOrDefault(u => u.Id == category.Id);

                    if (categoryFound == null)
                    {
                        return View();
                    }

                    categoryFound.Description = category.Description;


                    return RedirectToAction(nameof(Index));
                }

                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var categoryFound = categoryList.FirstOrDefault(u => u.Id == id);

            if (categoryFound == null)
            {
                return NotFound();
            }

            return View(categoryFound);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            try
            {
                var categoryFound = categoryList.FirstOrDefault(u => u.Id == category.Id);

                if (categoryFound == null)
                {
                    return View();
                }


                categoryList.Remove(categoryFound);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
