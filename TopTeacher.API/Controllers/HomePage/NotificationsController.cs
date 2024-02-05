using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopTeacher.Application.Features.Notifications.Commends.Add;
using TopTeacher.Application.Features.Notifications.Queries.GetByAcademicYear;

namespace TopTeacher.API.Controllers.HomePage
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public NotificationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("addNotifications")]
        public async Task<IActionResult> AddNotifications()
        {
            var newNotificationsList = new NotificationsAddRequest();
            await mediator.Send(newNotificationsList);

            return Ok();
        }
        [HttpPost("getNotificationsByAcademicYear")]
        public async Task<IActionResult> GetNotificationsByAcademicYear([FromBody] NotificationsGetByAcademicYearRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
