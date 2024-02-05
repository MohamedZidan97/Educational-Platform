using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Account.SignIn
{
    public class AccountGetTokenRequest : IRequest<AccountResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
