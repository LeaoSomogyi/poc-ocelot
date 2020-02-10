using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Poc.Ocelot.Products.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() => Ok(new { message = "This will return all products" }));
        }
    }
}