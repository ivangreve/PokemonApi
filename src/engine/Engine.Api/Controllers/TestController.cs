using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/Test")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        [Route("HealthStatus")]
        public IActionResult HealthStatus()
        {

            return Ok(new { Status = "Api is alive" });
        }


        [HttpGet]
        [Route("ExceptionHandlingCheck")]
        public IActionResult ExceptionHandlingCheck()
        {
            throw new ArgumentException("Testing exception middleware handling");
        }


        [HttpGet]
        [Authorize]
        [Route("TestSecureEnpoint")]
        public IActionResult TestSecureEnpoint()
        {
            return Ok();
        }


        [HttpGet]
        [Route("TestNonSecureEnpoint")]
        public IActionResult TestNonSecureEnpoint()
        {
            return Ok();
        }
    }
}
