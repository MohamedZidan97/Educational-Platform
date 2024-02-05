using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;

namespace TopTeacher.Application.Features.Account.SignIn
{
    public class AccountGetTokenHandler : IRequestHandler<AccountGetTokenRequest, AccountResponse>
    {


        private readonly IAuthService auth;

        public AccountGetTokenHandler(IAuthService auth)
        {

            this.auth = auth;
        }

        public async Task<AccountResponse> Handle(AccountGetTokenRequest request, CancellationToken cancellationToken)
        {
            var response =  await auth.GetTokenAsync(request);


            return response;
        }
    }
}
