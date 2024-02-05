using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.ExamsModel
{
    public class ChooseQuestion
    {
        public Guid ChooseQuestionId { get; set; }
        public string Text { get; set; }

        // 4 chooses

        #region 4 choose
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }

        #endregion


        //  Relation With AcademicYear Table
        public Guid AcademicYearId { get; set; }
        public AcademicYear AcademicsYear { get; set; }
      

        public ChooseQuestion()
        {
            ChooseQuestionId = Guid.NewGuid();
        }
    }
}
