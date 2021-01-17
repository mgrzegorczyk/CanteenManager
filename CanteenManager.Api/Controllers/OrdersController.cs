using System.Threading.Tasks;
using CanteenManager.Infrastructure.Commands;
using CanteenManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(
            IAppCommandDispatcher appCommandDispatcher,
            IOrderService orderService
        ) : base(appCommandDispatcher)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await orderService.GetAllAsync();

            return Json(orders);
        }
    }
}