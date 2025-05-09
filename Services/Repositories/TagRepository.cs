using BusinessLogic.Models;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;

namespace DataAccess.Repositories

{
    public class TagRepository : ITagRepository
    {
        private readonly TagDAO _dao = TagDAO.Instance;
        public void AddTag(Tag tag)
        {
            _dao.AddTag(tag);
        }

        public void DeleteTag(int id)
        {
            _dao.DeleteTag(id);
        }
        public IEnumerable<Tag> GetAllTags()
        {
            return _dao.GetAllTags();
        }

        public Tag GetTagById(int id)
        {
            return _dao.GetTagById(id);
        }

        public void UpdateTag(Tag tag)
        {
            _dao.UpdateTag(tag);
        }
    }
}
