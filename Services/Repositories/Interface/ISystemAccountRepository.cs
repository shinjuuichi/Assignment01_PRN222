using BusinessLogic.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interface
{
    public interface ISystemAccountRepository
    {
        IEnumerable GetAllAccounts();
        SystemAccount GetAccountById(int id);
        void AddAccount(SystemAccount account);
        void UpdateAccount(SystemAccount account);
        void DeleteAccount(int id);
        SystemAccount GetAccountByEmail(string email, string password);
    }
}
