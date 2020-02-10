using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Poc.Ocelot.Payments.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() => Ok(new { message = "This will list all payment methods" }));
        }
    }
}