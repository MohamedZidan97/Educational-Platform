using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Entites.ExamsModel;
using TopTeacher.Entites.MaterialsModel;

namespace TopTeacher.Entites
{
    public class AcademicYear
    {

        public Guid AcademicYearId { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Material> materials { get; set; }

        public ICollection<Exam> exams { get; set; }
        public ICollection<ChooseQuestion> chooseQuestions { get; set; }
        public ICollection<TrueAndFalseQuestion> trueAndFalseQuestions { get; set; }
    }
}
