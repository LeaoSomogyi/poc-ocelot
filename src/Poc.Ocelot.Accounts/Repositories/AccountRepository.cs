using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poc.Ocelot.Accounts.Extensions;
using Poc.Ocelot.Accounts.Interfaces.Repositories;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext _dbContext;

        public AccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> FindToLoginAsync(string email, string password)
        {
            return await _dbContext.Set<Account>().FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password.Cript()));
        }
    }
}
