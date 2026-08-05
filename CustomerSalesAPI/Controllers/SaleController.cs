using CustomerSales.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var sales = await saleService.GetSalesAsync();
            return Ok(sales);
        }
    }
}
