using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopTeacher.Application.Features.Materials.Commends.Add;
using TopTeacher.Application.Features.Materials.Commends.Delete;
using TopTeacher.Application.Features.Materials.Commends.Update;
using TopTeacher.Application.Features.Materials.Queries.Get;
using TopTeacher.Application.Features.Materials.Queries.GetById;

namespace TopTeacher.API.Controllers.HomePage
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMediator mediator;

        public MaterialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("createLesson")]
        public async Task<IActionResult> CreateLesson([FromBody] MaterialsAddRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }


        [HttpGet("getMaterials")]
        public async Task<IActionResult> GetMaterials()
        {
            var request = new MaterialsGetRequest();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("deleteLesson")]
        public async Task<IActionResult> DeleteLesson([FromBody] MaterialsDeleteRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        [HttpPut("updateLesson")]
        public async Task<IActionResult> UpdateLesson([FromBody] MaterialsUpdateRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        [HttpPost("getLessonById")]
        public async Task<IActionResult> GetLessonById([FromBody] MaterialsGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
