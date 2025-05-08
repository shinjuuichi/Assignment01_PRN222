using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class NewsArticleDAO
    {
        private readonly FunewsManagementContext _context;

        public NewsArticleDAO(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<NewsArticle> AddAsync(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);
            await _context.SaveChangesAsync();
            return newsArticle;
        }

        public async Task<List<NewsArticle>> GetAllAsync()
        {
            return await _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.Tags)
                .Include(n => n.CreatedBy)
                .ToListAsync();
        }

        public async Task<NewsArticle?> GetByIdAsync(string id)
        {
            return await _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.Tags)
                .Include(n => n.CreatedBy)
                .FirstOrDefaultAsync(n => n.NewsArticleId == id);
        }

        public async Task<bool> UpdateAsync(NewsArticle newsArticle)
        {
            var existing = await _context.NewsArticles.FindAsync(newsArticle.NewsArticleId);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(newsArticle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle == null)
                return false;

            _context.NewsArticles.Remove(newsArticle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
