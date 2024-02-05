using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopTeacher.Application.Features.Exams.Commends.Add;
using TopTeacher.Application.Features.Exams.Commends.Delete;
using TopTeacher.Application.Features.Exams.Commends.Update;
using TopTeacher.Application.Features.Exams.Queries.Get;

namespace TopTeacher.API.Controllers.ExamsContollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExamController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("getExams")]
        public async Task<IActionResult> GetExams()
        {
            var request = new ExamGetRequest();

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addExam")]
        public async Task<IActionResult> AddExam([FromBody] ExamAddRequest request)
        {
            await mediator.Send(request);
            return Ok("True");
        }
        [HttpPut("updateExam/{ExamId}")]
        public async Task<IActionResult> UpdateExam(Guid ExamId, [FromBody] ExamUpdateRequest request1)
        {
            var request2 = new ExamUpdateCommend()
            {
                ExamId = ExamId,
                Name = request1.Name,
                Description = request1.Description,
                AcademicYearId = request1.AcademicYearId,
                Type = request1.Type,

            };
            var response = await mediator.Send(request2);
            return Ok(response);
        }

        [HttpDelete("deleteExam/{ExamId}")]
        public async Task<IActionResult> DeleteExam(Guid ExamId)
        {
            var request = new ExamDeleteRequest { ExamId = ExamId };

            var response = await mediator.Send(request);

            return Ok(response);
        }
        [HttpGet("getExamById")]
        public async Task<IActionResult> GetExamById()
        {
            return Ok();
        }
    }
}
