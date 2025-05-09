using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        private FunewsManagementContext _context;

        public IEnumerable<Category> GetAllCategories(bool includeInactive = false)
        {
            var query = _context.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.InverseParentCategory)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(c => c.IsActive == true);
            }

            return query.ToList();
        }

        public Category GetCategoryById(short id)
        {
            return _context.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.InverseParentCategory)
                .FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.Find(category.CategoryId);
            if (existingCategory != null)
            {
                _context.Entry(existingCategory).CurrentValues.SetValues(category);
                _context.SaveChanges();
            }
        }

        public bool DeleteCategory(short id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                var hasArticles = _context.NewsArticles.Any(na => na.CategoryId == id);
                var hasSubCategories = _context.Categories.Any(c => c.ParentCategoryId == id);
                if (!hasArticles && !hasSubCategories)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Category> SearchCategories(string keyword)
        {
            return _context.Categories
                .Include(c => c.ParentCategory)
                .Where(c => c.CategoryName.Contains(keyword) || c.CategoryDesciption.Contains(keyword))
                .ToList();
        }
    }
}