using BusinessLogic.Models;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class TagDAO : SingletonBase<TagDAO>
    {
        private FunewsManagementContext _context;
        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTagById(int id)
        {
            return _context.Tags.Find(id);
        }

        public void AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void UpdateTag(Tag tag)
        {
            var existingTag = _context.Tags.Find(tag.TagId);
            if (existingTag == null) return;
            _context.Tags.Update(tag);
            _context.SaveChanges();
        }

        public void DeleteTag(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }
    }
}