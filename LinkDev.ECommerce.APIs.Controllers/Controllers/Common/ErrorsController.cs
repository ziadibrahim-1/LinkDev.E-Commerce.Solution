using LinkDev.ECommerce.APIs.Controllers.Error;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.APIs.Controllers.Controllers.Common
{
    [ApiController]
    [Route("/Errors/{Code}")]
    [ApiExplorerSettings(IgnoreApi =false)]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int Code)
        {
            if(Response.StatusCode == (int) HttpStatusCode.NotFound)
            {
                var response = new ApiResponse((int)HttpStatusCode.NotFound, $"The Requsted endpoint: {Request.Path} is not found.");
                return NotFound(response);
            }
            if(Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                var response = new ApiResponse((int)HttpStatusCode.Unauthorized, $"The Requsted endpoint: {Request.Path} is un authorized .");
                return BadRequest(response);
            }
            return StatusCode(Code);
        }
    }
}
