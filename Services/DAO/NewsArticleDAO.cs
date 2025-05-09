using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class NewsAritcleDAO : SingletonBase<NewsAritcleDAO>
    {
        private FunewsManagementContext _context;

        public IEnumerable<NewsArticle> GetAllNewsArticles(bool includeInactive = false)
        {
            var query = _context.NewsArticles
                .Include(na => na.Category)
                .Include(na => na.CreatedBy)
                .Include(na => na.Tags)
                .AsQueryable();

            if (!includeInactive)
            {
                query = query.Where(na => na.NewsStatus == true);
            }

            return query.ToList();
        }

        public NewsArticle GetNewsArticleById(string id)
        {
            return _context.NewsArticles
                .Include(na => na.Category)
                .Include(na => na.CreatedBy)
                .Include(na => na.Tags)
                .FirstOrDefault(na => na.NewsArticleId == id);
        }

        public void AddNewsArticle(NewsArticle article)
        {
            _context.NewsArticles.Add(article);
            _context.SaveChanges();
        }

        public void UpdateNewsArticle(NewsArticle article)
        {
            var existingArticle = _context.NewsArticles
                .Include(na => na.Tags)
                .FirstOrDefault(na => na.NewsArticleId == article.NewsArticleId);

            if (existingArticle != null)
            {
                _context.Entry(existingArticle).CurrentValues.SetValues(article);

                existingArticle.Tags.Clear();
                foreach (var tag in article.Tags)
                {
                    var existingTag = _context.Tags.Find(tag.TagId);
                    if (existingTag != null)
                    {
                        existingArticle.Tags.Add(existingTag);
                    }
                }

                _context.SaveChanges();
            }
        }

        public void DeleteNewsArticle(string id)
        {
            var article = _context.NewsArticles.Find(id);
            if (article != null)
            {
                _context.NewsArticles.Remove(article);
                _context.SaveChanges();
            }
        }

        public IEnumerable<NewsArticle> SearchNewsArticles(string keyword)
        {
            return _context.NewsArticles
                .Include(na => na.Category)
                .Include(na => na.CreatedBy)
                .Include(na => na.Tags)
                .Where(na => na.NewsTitle.Contains(keyword) || na.NewsContent.Contains(keyword))
                .ToList();
        }

        public IEnumerable<NewsArticle> GetNewsArticlesByStaff(short accountId)
        {
            return _context.NewsArticles
                .Include(na => na.Category)
                .Include(na => na.CreatedBy)
                .Include(na => na.Tags)
                .Where(na => na.CreatedById == accountId)
                .ToList();
        }

        public IEnumerable<NewsArticle> GetNewsStatistics(DateTime startDate, DateTime endDate)
        {
            return _context.NewsArticles
                .Include(na => na.Category)
                .Include(na => na.CreatedBy)
                .Include(na => na.Tags)
                .Where(na => na.CreatedDate >= startDate && na.CreatedDate <= endDate)
                .OrderByDescending(na => na.CreatedDate)
                .ToList();
        }
    }
}