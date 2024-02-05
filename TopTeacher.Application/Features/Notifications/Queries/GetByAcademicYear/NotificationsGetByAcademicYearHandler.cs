using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;

namespace TopTeacher.Application.Features.Notifications.Queries.GetByAcademicYear
{
    public class NotificationsGetByAcademicYearHandler : IRequestHandler<NotificationsGetByAcademicYearRequest, IEnumerable<NotificationsGetByAcademicYearResponse>>
    {
        private readonly IHelper helper;

        public NotificationsGetByAcademicYearHandler(IHelper helper)
        {
            this.helper = helper;
        }
        public async Task<IEnumerable<NotificationsGetByAcademicYearResponse>> Handle(NotificationsGetByAcademicYearRequest request, CancellationToken cancellationToken)
        {
            var response = await helper.GetByAcademicYearAsync(request);

            return response;

        }
    }
}
