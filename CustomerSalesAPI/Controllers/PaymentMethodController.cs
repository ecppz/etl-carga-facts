using CustomerSales.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            this.paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var methods = await paymentMethodService.GetPaymentMethodsAsync();
            return Ok(methods);
        }
    }
}
