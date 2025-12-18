using E_commerace.Shared.Dtos.Auth;
using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Identity;
using E_Commerace.Domain.Exceptions.BadRequest;
using E_Commerace.Domain.Exceptions.NotFound;
using E_Commerace.Domain.Exceptions.UnAuthorized;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Services
{
    public class AuthService(UserManager<AppUser> _userManager, IConfiguration configuration) : IAuthService
    {
        public async Task<UserResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new LoginNotFound(request.Email);
            bool flag = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!flag) throw new UnAuthorizedError();
            return new UserResponse
            {
                DisplayName = user.DisplayName,

                Email = user.Email,
                Token =await  GenerateJwtToken(user)
            };
        }


        public async Task<UserResponse?> RegisterAsync(RegisterRequest registerRequst)
        {
            var user = new AppUser
            {
                DisplayName = registerRequst.DisplayName,
                Email = registerRequst.Email,
                UserName = registerRequst.UserName,
                PhoneNumber = registerRequst.PhoneNumber
            };
            var result = _userManager.CreateAsync(user, registerRequst.Password).Result;
            if (!result.Succeeded) throw new RegisterationBadRequestException(result.Errors.Select(e => e.Description).ToList());
            return new UserResponse
            {
                DisplayName = user.DisplayName,

                Email = user.Email,
                Token = await GenerateJwtToken(user)
            };
        }
        //to generate token later
        private async Task <string> GenerateJwtToken(AppUser user)
        {  
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:secretKey"]));
            var claims = new List<Claim>()
            {
              new Claim(ClaimTypes.GivenName, user.DisplayName),
          new Claim(      ClaimTypes.Email , user.Email),
         //  new Claim(     ClaimTypes.MobilePhone , user.PhoneNumber)
            };
            var roles=_userManager.GetRolesAsync(user).Result;
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var token = new JwtSecurityToken(
                           issuer: configuration["JwtSettings:validIssuer"],
                audience:configuration["JwtSettings:validAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(double.Parse(configuration["JwtSettings:expiresIn"])),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
           );
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
