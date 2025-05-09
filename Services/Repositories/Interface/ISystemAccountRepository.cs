using BusinessLogic.Models;

namespace DataAccess.Repositories.Interface
{
    public interface ISystemAccountRepository
    {
        IEnumerable<SystemAccount> GetAllAccounts();
        SystemAccount GetAccountById(int id);
        void AddAccount(SystemAccount account);
        void UpdateAccount(SystemAccount account);
        void DeleteAccount(int id);
        SystemAccount GetAccountByEmail(string email, string password);
    }
}
