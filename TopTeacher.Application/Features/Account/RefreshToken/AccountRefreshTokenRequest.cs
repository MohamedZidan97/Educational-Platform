using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Account.RefreshToken
{
    public class AccountRefreshTokenRequest : IRequest<AccountResponse>
    {
        public string Token { get; set; }   
    }
}
