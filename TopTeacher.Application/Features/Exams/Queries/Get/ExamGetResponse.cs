using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Exams.Queries.Get
{
    public class ExamGetResponse
    {

        public Guid ExamId { get; set; }
        public string Name { get; set; }

        public Guid AcademicYearId { get; set; }
    }
}
