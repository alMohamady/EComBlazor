using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs.Payments;
using Microsoft.AspNetCore.Mvc;

namespace EComBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentMethodService payService) : ControllerBase
    {
        [HttpGet("payMethods")]
        public async Task<ActionResult<IEnumerable<PaymentMethodDto>>> GetPaymentMethodes()
        {
            var methods = await payService.GetPaymentMethod();
            if (methods.Any())
                return NotFound();
            else
                return Ok(methods);
        }
    }
}
