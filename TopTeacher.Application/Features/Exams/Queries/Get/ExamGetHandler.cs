using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.ExamsModel;

namespace TopTeacher.Application.Features.Exams.Queries.Get
{
    public class ExamGetHandler : IRequestHandler<ExamGetRequest, IEnumerable<ExamGetResponse>>
    {
        private readonly IBaseRepositories<Exam> rep;
        private readonly IMapper mapper;

        public ExamGetHandler(IBaseRepositories<Exam> rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ExamGetResponse>> Handle(ExamGetRequest request, CancellationToken cancellationToken)
        {
            var allRows = await rep.GetAllAsync();

            var response = mapper.ProjectTo<ExamGetResponse>(allRows.AsQueryable());

            return response;
        }
    }
}
