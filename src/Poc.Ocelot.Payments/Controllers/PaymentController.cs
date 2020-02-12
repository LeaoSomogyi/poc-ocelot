using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Poc.Ocelot.Payments.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() => Ok(new { message = "This will list all payment methods" }));
        }
    }
}
