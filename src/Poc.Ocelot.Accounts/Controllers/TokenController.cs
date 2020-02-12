using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poc.Ocelot.Accounts.Interfaces.Services;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public TokenController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost, Route("authorize")]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize([FromBody] Account account)
        {
            var result = await _accountService.Authenticate(account);

            return Ok(result);
        }
    }
}
