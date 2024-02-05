using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Notifications.Queries.GetByAcademicYear
{
    public class NotificationsGetByAcademicYearRequest : IRequest<IEnumerable<NotificationsGetByAcademicYearResponse>>
    {
        public string AcademicYear { get; set; }
    }
}
