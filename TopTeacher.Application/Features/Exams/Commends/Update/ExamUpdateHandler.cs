using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.ExamsModel;

namespace TopTeacher.Application.Features.Exams.Commends.Update
{
    public class ExamUpdateHandler : IRequestHandler<ExamUpdateCommend, ExamUpdateResponse>
    {
        private readonly IBaseRepositories<Exam> rep;
        private readonly IMapper mapper;

        public ExamUpdateHandler(IBaseRepositories<Exam> rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        public async Task<ExamUpdateResponse> Handle(ExamUpdateCommend request, CancellationToken cancellationToken)
        {
            var _mapper = mapper.Map<Exam>(request);
            var checkModify = await rep.Update2Async(_mapper);

            var response = new ExamUpdateResponse() { Success= checkModify };

            return response;
        }
    }
}
