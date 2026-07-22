using LinkDev.ECommerce.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.ECommerce.APIs.Controllers.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public BaseApiController(IServiceManager serviceManager)
        {
        }
    }
}
