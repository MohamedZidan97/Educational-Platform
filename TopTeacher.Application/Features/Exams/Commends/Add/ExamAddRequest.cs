using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Exams.Commends.Add
{
    public class ExamAddRequest : IRequest
    {

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }
        public Guid AcademicYearId { get; set; }

    }
}
