using BusinessLogic;
using BusinessLogic.Models;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _dao = CategoryDAO.Instance;

        public CategoryRepository(FunewsManagementContext context)
        {
            _dao.InitializeContext(context);
        }

        public void AddCategory(Category category)
        {
            _dao.AddCategory(category);
        }

        public bool DeleteCategory(short id)
        {
            return _dao.DeleteCategory(id);
        }

        public IEnumerable<Category> GetAllCategories(bool includeInactive)
        {
            return _dao.GetAllCategories(includeInactive);
        }

        public Category GetCategoryById(short id)
        {
            return _dao.GetCategoryById(id);
        }

        public IEnumerable<Category> SearchCategories(string keyword)
        {
            return _dao.SearchCategories(keyword);
        }

        public void UpdateCategory(Category category)
        {
            _dao.UpdateCategory(category);
        }
    }
}
