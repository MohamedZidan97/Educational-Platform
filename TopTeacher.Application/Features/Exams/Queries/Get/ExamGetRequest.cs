using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Exams.Queries.Get
{
    public class ExamGetRequest : IRequest<IEnumerable<ExamGetResponse>>
    {
        // no thing
    }
}
