using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Features.Account.Register;
using TopTeacher.Application.Features.Account;
using TopTeacher.Application.Features.Account.SignIn;

namespace TopTeacher.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AccountResponse> RegisterAsync(AccountRegisterRequest request);

        Task<AccountResponse> GetTokenAsync(AccountGetTokenRequest request);

        // Task<string> AddRoleAsync(AddRoleM roleM);

         Task<AccountResponse> CheckOrCreateRefreshTokenAsync(string refreshToken);

        // if you want Revoked for token is active, use this method
        //Task<bool> RevokedTokenAsync(string refreshToken);
    }
}
