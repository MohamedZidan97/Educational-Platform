using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;

namespace TopTeacher.Application.Features.Account.Register
{
    public class AccountRegisterHandler : IRequestHandler<AccountRegisterRequest, AccountResponse>
    {
        private readonly IAuthService auth;

        public AccountRegisterHandler(IAuthService auth)
        {
            this.auth = auth;
        }

        public async Task<AccountResponse> Handle(AccountRegisterRequest request, CancellationToken cancellationToken)
        {
            var response = await auth.RegisterAsync(request);
           
           

            return response;
        }
    }
}
