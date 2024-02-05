using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TopTeacher.Application.Features.Account.RefreshToken;
using TopTeacher.Application.Features.Account.Register;
using TopTeacher.Application.Features.Account.SignIn;

namespace TopTeacher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("registerToken")]
        public async Task<IActionResult> RegisterToken([FromBody] AccountRegisterRequest request)
        {

            var response = await mediator.Send(request);

            if(!response.IsAuthenticed)
                return BadRequest(response.Message);


            return Ok(response);

        }
        [HttpPost("getToken")]
        public async Task<IActionResult> GetToken(AccountGetTokenRequest request)
        {

            var response = await mediator.Send(request);

            if (!response.IsAuthenticed)
                return BadRequest(response.Message);

            //if (!string.IsNullOrEmpty(response.RefreshToken))
            //{
            //   SetRefreshTokenInCookie(response.RefreshToken, response.RefreshTokenExpiration);
            //}


            return Ok(response);

        }
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(AccountRefreshTokenRequest request)
        {

            var response = await mediator.Send(request);

            if (!response.IsAuthenticed)
                return BadRequest(response.Message);

            return Ok(response);

        }

        // Send Cookie To api send with request true token 

        private void SetRefreshTokenInCookie(string refreshToken, DateTime? expire)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expire
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);

        }

    }
}
