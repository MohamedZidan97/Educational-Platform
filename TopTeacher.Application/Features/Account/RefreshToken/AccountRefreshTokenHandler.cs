using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;

namespace TopTeacher.Application.Features.Account.RefreshToken
{
    public class AccountRefreshTokenHandler : IRequestHandler<AccountRefreshTokenRequest, AccountResponse>
    {
        private readonly IAuthService auth;

        public AccountRefreshTokenHandler(IAuthService auth)
        {

            this.auth = auth;
        }
        public async Task<AccountResponse> Handle(AccountRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var response = await auth.CheckOrCreateRefreshTokenAsync(request.Token);

            return response;
        }
    }
}
