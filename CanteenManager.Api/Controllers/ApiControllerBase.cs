using CanteenManager.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        protected readonly IAppCommandDispatcher AppCommandDispatcher;

        protected ApiControllerBase(IAppCommandDispatcher appCommandDispatcher)
        {
            this.AppCommandDispatcher = appCommandDispatcher;
        }
    }
}