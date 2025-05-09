
using BusinessLogic.Models;
using DataAccess;
using Repositories.Interface;
using System.Collections;

namespace Repositories
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

        public IEnumerable GetAllAccounts()
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
