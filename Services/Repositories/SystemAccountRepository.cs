using BusinessLogic.Models;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;

namespace DataAccess.Repositories
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly SystemAccountDAO _dao = SystemAccountDAO.Instance;
        public void AddAccount(SystemAccount account)
        {
            _dao.AddAccount(account);
        }

        public void DeleteAccount(int id)
        {
            _dao.DeleteAccount(id);
        }

        public SystemAccount GetAccountById(int id)
        {
            return _dao.GetAccountById(id);
        }

        public IEnumerable<SystemAccount> GetAllAccounts()
        {
            return _dao.GetAllAccounts();
        }

        public void UpdateAccount(SystemAccount account)
        {
            _dao.UpdateAccount(account);
        }

        public SystemAccount GetAccountByEmail(string email, string password)
        {
            return _dao.GetAccountByEmail(email, password);
        }
    }
}
