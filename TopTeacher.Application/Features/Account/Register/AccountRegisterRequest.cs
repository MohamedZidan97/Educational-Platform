using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Account.Register
{
    public class AccountRegisterRequest : IRequest<AccountResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentGuardian { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid AcademicYearId { get; set; }

        public bool IsOnline { get; set; }

    }
}
