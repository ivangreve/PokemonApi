using Microsoft.AspNetCore.Mvc;
using System;

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
        [Route("HelthCheck")]
        public IActionResult HelthCheck()
        {

            return Ok(new { Status = "Api is alive" });
        }


        [HttpGet]
        [Route("ExceptionHandlingCheck")]
        public IActionResult ExceptionHandlingCheck()
        {
            throw new ArgumentException("Testing exception middleware handling");
        }
    }
}
