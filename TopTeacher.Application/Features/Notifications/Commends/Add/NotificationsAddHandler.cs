using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;

namespace TopTeacher.Application.Features.Notifications.Commends.Add
{
    public class NotificationsAddHandler : IRequestHandler<NotificationsAddRequest>
    {
        private readonly IHelper helper;

        public NotificationsAddHandler(IHelper helper)
        {
            this.helper = helper;
        }

        public async Task Handle(NotificationsAddRequest request, CancellationToken cancellationToken)
        {
            await helper.AddNotifications();
        }
    }
}
