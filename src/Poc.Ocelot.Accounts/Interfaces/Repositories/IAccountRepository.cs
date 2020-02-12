using System;
using System.Threading.Tasks;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> FindToLoginAsync(string email, string password);
    }
}
