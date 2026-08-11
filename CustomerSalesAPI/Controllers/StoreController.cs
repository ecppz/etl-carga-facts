using CustomerSales.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var stores = await storeService.GetStoresAsync();
            return Ok(stores);
        }
    }
}
