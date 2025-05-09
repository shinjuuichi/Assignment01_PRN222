using BusinessLogic.Models;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;

namespace DataAccess.Repositories
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly NewsArticleDAO _dao = NewsArticleDAO.Instance;

        public void AddNewsArticle(NewsArticle article)
        {
            _dao.AddNewsArticle(article);
        }

        public void DeleteNewsArticle(string id)
        {
            _dao.DeleteNewsArticle(id);
        }

        public IEnumerable<NewsArticle> GetAllNewsArticles(bool includeInactive = false)
        {
            return _dao.GetAllNewsArticles(includeInactive);
        }

        public NewsArticle GetNewsArticleById(string id)
        {
            return _dao.GetNewsArticleById(id);
        }

        public IEnumerable<NewsArticle> GetNewsArticlesByStaff(short accountId)
        {
            return _dao.GetNewsArticlesByStaff(accountId);
        }

        public IEnumerable<NewsArticle> GetNewsStatistics(DateTime startDate, DateTime endDate)
        {
            return _dao.GetNewsStatistics(startDate, endDate);
        }

        public IEnumerable<NewsArticle> SearchNewsArticles(string keyword)
        {
            return _dao.SearchNewsArticles(keyword);
        }

        public void UpdateNewsArticle(NewsArticle article)
        {
            _dao.UpdateNewsArticle(article);
        }
    }
}