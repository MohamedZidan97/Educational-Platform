using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CodeStyle;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Features.Notifications.Queries.GetByAcademicYear;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites;
using TopTeacher.Entites.NotificationsModel;

namespace TopTeacher.Persistance.Repositories
{
    public class HelperRepositories : IHelper
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public HelperRepositories(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task AddNotifications()
        {
            var lastNotificationDate = context.notifications.MaxAsync(e => e.CreatedDate).Result;
            Console.WriteLine(lastNotificationDate);
            var newNotificationsList = context.materials
                .Where(et => et.CreatedDate >= lastNotificationDate)
                .Select(e => new Notification
                {
                    AcademicYear = context.academicYears
                        .Where(f => f.AcademicYearId == e.AcademicYearId)
                        .Select(r => r.Name)
                        .FirstOrDefault(), // or SingleOrDefault() depending on your data model
                    Title = e.Name,
                    Description = $"Unit: {e.Unit}, Lesson: {e.Lesson}"
                })
                .ToListAsync().Result;


            if (newNotificationsList != null)
            {
                await context.notifications.AddRangeAsync(newNotificationsList);

                await context.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<NotificationsGetByAcademicYearResponse>> GetByAcademicYearAsync(NotificationsGetByAcademicYearRequest request)
        {
            var response = context.notifications.Where(e => e.AcademicYear == request.AcademicYear)
                .Select(s => new NotificationsGetByAcademicYearResponse
                {
                    Title = s.Title,
                    Description = s.Description,
                    AcademicYear = request.AcademicYear
                }).ToListAsync().Result;


            return response;
        }
    }
}
