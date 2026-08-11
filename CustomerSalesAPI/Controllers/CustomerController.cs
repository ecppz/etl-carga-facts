using CustomerSales.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await customerService.GetCustomersAsync();
            return Ok(customers);
        }
    }
}
