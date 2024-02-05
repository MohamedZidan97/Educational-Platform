using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.ExamsModel;

namespace TopTeacher.Application.Features.Exams.Commends.Delete
{
    public class ExamDeleteHandler : IRequestHandler<ExamDeleteRequest, ExamDeleteResponse>
    {
        private readonly IBaseRepositories<Exam> rep;

        public ExamDeleteHandler(IBaseRepositories<Exam> rep)
        {
            this.rep = rep;
        }

        public async Task<ExamDeleteResponse> Handle(ExamDeleteRequest request, CancellationToken cancellationToken)
        {

            var response = new ExamDeleteResponse() { Success = await rep.Delete2Async(request.ExamId) };
            return response;
        }
    }
}
