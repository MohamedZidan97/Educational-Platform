using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.ExamsModel;

namespace TopTeacher.Application.Features.Exams.Commends.Add
{
    public class ExamAddHandler : IRequestHandler<ExamAddRequest>
    {
        private readonly IBaseRepositories<Exam> rep;
        private readonly IMapper mapper;

        public ExamAddHandler(IBaseRepositories<Exam> Rep, IMapper mapper)
        {
            rep = Rep;
            this.mapper = mapper;
        }

        public async Task Handle(ExamAddRequest request, CancellationToken cancellationToken)
        {
            var rmapper = mapper.Map<Exam>(request);

            await rep.AddAsync(rmapper);
        }
    }
}
