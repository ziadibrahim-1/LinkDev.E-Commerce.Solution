using LinkDev.ECommerce.APIs.Controllers.Controllers.Base;
using LinkDev.ECommerce.APIs.Controllers.Error;
using LinkDev.ECommerce.Application.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LinkDev.ECommerce.APIs.Controllers.Controllers.Buggy
{
    public class BuggyController : BaseApiController
    {
        public BuggyController(IServiceManager serviceManager)
            : base(serviceManager)
        {
            
        }

        [HttpGet("not-found")]
        public IActionResult GetNotFoundRequest()
        {
            return NotFound(new { StatusCode = 404, Message = "This is a not found request." }); //404
        }

        [HttpGet("server-error")]
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception(); //500
        }
        [HttpGet("bad-request")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new {Message = "Bad Request!!" , StatusCode= 400}); //400
        }

        [HttpGet("bad-request/{id}")]
        public IActionResult GetValidationErrorRequest(int id)
        {
            if (!ModelState.IsValid)
            {
                
            }
            return Ok();
        }
        
        [HttpGet("unauthorized")] // Get: /api/buggy/unauthorized
        public IActionResult GetUnauthorizedErrorRequest()
        {
            return Unauthorized(); //401
        }

        [HttpGet("forbidden")] // Get: /api/buggy/forbidden
        public IActionResult GetForbiddenErrorRequest()
        {
            return Forbid(); //403
        }

    }
}
