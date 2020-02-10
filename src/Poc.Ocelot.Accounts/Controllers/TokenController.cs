using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poc.Ocelot.Accounts.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TokenController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet, Route("authorize")]
        public async Task<IActionResult> GenerateToken()
        {
            var token = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
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