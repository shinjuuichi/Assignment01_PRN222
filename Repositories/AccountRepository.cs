using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly NewsArticleDAO _accountDAO;

        public AccountRepository(NewsArticleDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public AccountMember GetAccountByEmail(string email) => _accountDAO.GetAccountByEmail(email);
    }
}
