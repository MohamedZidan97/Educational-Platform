using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.ExamsModel
{
    public class TrueAndFalseQuestion
    {
        public Guid TrueAndFalseQuestionId { get; set; }


        public string Text { get; set; }
        
        // TOrF
        #region TrueOrFalse
        public bool IsTrue { get; set; }
        public bool IsFalse { get; set; }
        #endregion


        //  Relation With AcademicYear Table
        public Guid AcademicYearId { get; set; }
        public AcademicYear AcademicsYear { get; set; }

       
        public TrueAndFalseQuestion()
        {
            TrueAndFalseQuestionId = Guid.NewGuid();
        }
    }
}
