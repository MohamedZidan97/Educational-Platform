using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Entites;

namespace TopTeacher.Application.Features.Exams.Commends.Update
{
    public class ExamUpdateRequest
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }




        //  Relation With AcademicYear Table

        public Guid AcademicYearId { get; set; }

    }
}
