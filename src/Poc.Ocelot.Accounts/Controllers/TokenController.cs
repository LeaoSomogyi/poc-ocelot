using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace Poc.Ocelot.Accounts.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet, Route("authorize")]
        public async Task<IActionResult> GenerateToken()
        {
            var token = await new HttpClient().RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
            {
                Address = "https://localhost:6001/connect/token",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret",
                Scope = "OcelotPOC"
            });

            return Ok(token.Json);
        }
    }
}
