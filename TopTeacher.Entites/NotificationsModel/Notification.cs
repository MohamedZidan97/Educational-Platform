using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.NotificationsModel
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }


        public string AcademicYear { get; set; }





        public Notification()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
