using BusinessLogic.Models;

namespace DataAccess.Repositories.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories(bool includeInactive = false);
        Category GetCategoryById(short id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        bool DeleteCategory(short id);
        IEnumerable<Category> SearchCategories(string keyword);
    }
}
