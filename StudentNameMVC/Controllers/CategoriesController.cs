using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;
using BusinessLogic.Models;
using DataAccess.Repositories.Interface;

namespace StudentNameMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: Categories
        public IActionResult Index(string searchString)
        {
            var categories = _categoryRepository.GetAllCategories();
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = _categoryRepository.SearchCategories(searchString);
            }
            return View(categories);
        }

        // GET: Categories/Details/5
        public IActionResult Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["ParentCategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return PartialView("_CreateCategoryModal");
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,CategoryName,CategoryDesciption,ParentCategoryId,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return Json(new { success = true });
            }
            ViewData["ParentCategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", category.ParentCategoryId);
            return PartialView("_CreateCategoryModal", category);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["ParentCategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", category.ParentCategoryId);
            return PartialView("_EditCategoryModal", category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(short id, [Bind("CategoryId,CategoryName,CategoryDesciption,ParentCategoryId,IsActive")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.UpdateCategory(category);
                    return Json(new { success = true });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_categoryRepository.GetCategoryById(category.CategoryId) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            ViewData["ParentCategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", category.ParentCategoryId);
            return PartialView("_EditCategoryModal", category);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteCategoryModal", category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(short id)
        {
            var success = _categoryRepository.DeleteCategory(id);
            if (!success)
            {
                return Json(new { success = false, message = "Cannot delete category as it is linked to news articles or subcategories." });
            }
            return Json(new { success = true });
        }
    }
}