using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Notifications.Queries.GetByAcademicYear
{
    public class NotificationsGetByAcademicYearResponse
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AcademicYear { get; set; }
    }
}
