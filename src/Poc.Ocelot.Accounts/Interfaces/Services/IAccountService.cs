using System.Threading.Tasks;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Token> Authenticate(Account account, string claimPermission);
    }
}
