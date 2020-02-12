using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Poc.Ocelot.Products.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() => Ok(new { message = "This will return all products" }));
        }
    }
}
