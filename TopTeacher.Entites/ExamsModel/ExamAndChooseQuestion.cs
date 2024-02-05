using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.ExamsModel
{
   
    public class ExamAndChooseQuestion
    {
    
        //
        public Guid ChooseQuestionId { get; set; }
      
        //
        public Guid ExamId { get; set; }
    
    }
}
