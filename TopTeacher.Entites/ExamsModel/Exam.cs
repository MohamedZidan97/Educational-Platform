using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.ExamsModel
{
    public class Exam
    {
        public Guid ExamId { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }


     

        //  Relation With AcademicYear Table

        public Guid AcademicYearId { get; set; }

        public AcademicYear AcademicYear { get; set; }

  

        public Exam()
        {
            ExamId = Guid.NewGuid();
        }
    }
}
