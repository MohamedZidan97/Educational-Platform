using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Features.Notifications.Queries.GetByAcademicYear;

namespace TopTeacher.Application.Interfaces
{
    public interface IHelper
    {
        Task AddNotifications();
        Task<IEnumerable<NotificationsGetByAcademicYearResponse>> GetByAcademicYearAsync(NotificationsGetByAcademicYearRequest request);
    }
}
