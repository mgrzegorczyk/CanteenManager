using Microsoft.AspNetCore.Mvc;

namespace CanteenManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string TestAction()
        {
            return "Hello, working fine! :)";
        }
    }
}