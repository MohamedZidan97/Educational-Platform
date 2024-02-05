using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Exams.Commends.Delete
{
    public class ExamDeleteRequest : IRequest<ExamDeleteResponse>
    {
        public Guid ExamId { get; set; }
    }
}
