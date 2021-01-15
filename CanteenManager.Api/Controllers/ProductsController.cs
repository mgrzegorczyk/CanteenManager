using System.Threading.Tasks;
using CanteenManager.Infrastructure.Commands;
using CanteenManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IAppCommandDispatcher appCommandDispatcher;
        private readonly IProductService productService;

        public ProductsController(
            IAppCommandDispatcher appCommandDispatcher,
            IProductService productService
        ) : base(appCommandDispatcher)
        {
            this.appCommandDispatcher = appCommandDispatcher;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetAllAsync();

            return Json(products);
        }
    }
}