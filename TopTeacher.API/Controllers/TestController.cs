using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TopTeacher.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       
        [HttpGet("test")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> TestMethod()
        {


            return Ok("Good");
        }
    }
}
