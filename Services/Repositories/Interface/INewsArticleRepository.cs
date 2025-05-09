using BusinessLogic.Models;

namespace DataAccess.Repositories.Interface
{
    public interface INewsArticleRepository
    {
        IEnumerable<NewsArticle> GetAllNewsArticles(bool includeInactive = false);
        NewsArticle GetNewsArticleById(string id);
        void AddNewsArticle(NewsArticle article);
        void UpdateNewsArticle(NewsArticle article);
        void DeleteNewsArticle(string id);
        IEnumerable<NewsArticle> SearchNewsArticles(string keyword);
        IEnumerable<NewsArticle> GetNewsArticlesByStaff(short accountId);
        IEnumerable<NewsArticle> GetNewsStatistics(DateTime startDate, DateTime endDate);
    }
}
