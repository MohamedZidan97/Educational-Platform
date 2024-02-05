using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Exams.Commends.Update
{
    public class ExamUpdateCommend : ExamUpdateRequest , IRequest<ExamUpdateResponse>
    {
        public Guid ExamId { get; set; }
    }
}
