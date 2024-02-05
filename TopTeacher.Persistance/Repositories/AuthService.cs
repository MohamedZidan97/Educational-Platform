using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Features.Account;
using TopTeacher.Application.Features.Account.Register;
using TopTeacher.Application.Features.Account.SignIn;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites;
using TopTeacher.Persistance.Helper;

namespace TopTeacher.Persistance.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly JWT jwt;
        private readonly UserManager<ApplicationUser> userManager;
       
        private readonly FunctionsOfHelper helper;

        public AuthService(IOptions<JWT> jwt, UserManager<ApplicationUser> userManager, FunctionsOfHelper helper)
        {
            this.jwt = jwt.Value;
            this.userManager = userManager;
            this.helper = helper;
        }
        public async Task<AccountResponse> RegisterAsync(AccountRegisterRequest request)
        {
            if (await userManager.FindByEmailAsync(request.Email) is not null)
                return new AccountResponse { Message = "Email Is already Recoerd" };
            if (await userManager.FindByNameAsync(request.PhoneNumber) is not null)
                return new AccountResponse { Message = "Number Is already Recoerd"};

           
            var user = new ApplicationUser()
            {
                Name = request.Name,
                PhoneNumber= request.PhoneNumber,
                PhoneNumberOfStudentGuardian=request.StudentGuardian,
                Email = request.Email,
                UserName=request.Email,
                AcademicYear = helper.GetAcademic(request.AcademicYearId).Result,
                IsOnline=request.IsOnline

            };


            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = String.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AccountResponse { Message = errors };
            }

            await userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);
            var generateRefreshToken = await GenerateRefreshToken();
            user.RefreshTokens.Add(generateRefreshToken);
            await userManager.UpdateAsync(user);




            return new AccountResponse
            {
                IsAuthenticed = true,
                Email = request.Email,
                PhoneNumber= request.PhoneNumber,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = generateRefreshToken.Token,
                RefreshTokenExpiration = generateRefreshToken.ExpiresOn
            };
        }

        public async Task<AccountResponse> GetTokenAsync(AccountGetTokenRequest request)
        {
            var response = new AccountResponse();
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                response.Message = "Email Or Password is incorect!";
                return response;
            }

          

            var jwtSecurityToken = await CreateJwtToken(user);
            response.IsAuthenticed = true;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.ExpiresOn = jwtSecurityToken.ValidTo;

            if (user.RefreshTokens.Any(act => act.IsActive))
            {
                var ActiveToken = user.RefreshTokens.First(act => act.IsActive);
                response.RefreshToken = ActiveToken.Token;
                response.RefreshTokenExpiration = ActiveToken.ExpiresOn;

            }
            else
            {
                var newRefreshToken = await GenerateRefreshToken();

                response.RefreshToken = newRefreshToken.Token;
                response.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

                user.RefreshTokens.Add(newRefreshToken);
                await userManager.UpdateAsync(user);
            }





            return response;
        }
        public async Task<AccountResponse> CheckOrCreateRefreshTokenAsync(string refreshToken)
        {

            var user = await userManager.Users.SingleOrDefaultAsync(tok => tok.RefreshTokens.Any(rt => rt.Token == refreshToken));

            var response = new AccountResponse();
            if (user == null)
            {
                response.Message = "Invalid token";
                return response;
            }

            var exictToken = user.RefreshTokens.Single(t => t.Token == refreshToken);

            if (!exictToken.IsActive)
            {
                response.Message = "Inactive token";
                return response;
            }

            // make old refresh token Revoked
            exictToken.RevokedOn = DateTime.UtcNow;

            // Add the new Token 
            var newRefreshToken = await GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await userManager.UpdateAsync(user);

            // Generate Token Authorization
            var jwtToken = await CreateJwtToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            // complete attributes of AuthModel
            response.IsAuthenticed = true;
            response.Email = user.Email;
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.ExpiresOn;


            return response;

        }


        #region Token
        private async Task<RefreshToken> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var Generator = new RNGCryptoServiceProvider();
            Generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddMinutes(jwt.DurationInMinutes),
                CreatedOn = DateTime.UtcNow
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        #endregion
    }
}
