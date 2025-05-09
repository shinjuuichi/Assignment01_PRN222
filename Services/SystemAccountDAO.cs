using BusinessLogic.Models;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SystemAccountDAO : SingletonBase<SystemAccountDAO>
    {
        private FunewsManagementContext _context;

        public IEnumerable<SystemAccount> GetAllAccounts()
        {
            return _context.SystemAccounts.ToList();
        }
        public SystemAccount GetAccountById(int id)
        {
            return _context.SystemAccounts.Find(id);
        }
        public void AddAccount(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            _context.SaveChanges();
        }
        public void UpdateAccount(SystemAccount account)
        {
            var existingAccount = _context.SystemAccounts.Find(account);
            if (existingAccount == null) return;
            _context.SystemAccounts.Update(account);
            _context.SaveChanges();
        }
        public void DeleteAccount(int id)
        {
            var existingAccount = _context.SystemAccounts.Find(id);
            if (existingAccount != null)
            {
                _context.SystemAccounts.Remove(existingAccount);
                _context.SaveChanges();
            }
        }
        public SystemAccount GetAccountByEmail(string email, string password)
        {
            var account = _context.SystemAccounts
                .SingleOrDefault(a =>
                    a.AccountEmail.Equals(email) &&
                    a.AccountPassword.Equals(password));
            if (account == null) return null;
            return account;
        }
    }
}
