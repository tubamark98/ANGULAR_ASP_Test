using Data.DB_Models;
using Logic.DTO_Models;
using Logic.Helpers;
using Logic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class AuthLogic : IAuthLogic
    {
        private IWorkerLogic workerLogic; //should somehow switch to UserManager
        private IConfiguration Configuration;
        public AuthLogic(IWorkerLogic workerLogic, IConfiguration configuration)
        {
            this.workerLogic = workerLogic;
            this.Configuration = configuration;
        }

        public async Task<TokenModel> LoginUser(LoginDTO login)
        {
            var user = new Worker();

            if(login.LoginName != null)
            {
                user = await workerLogic.FindByNameAsync(login.LoginName);
            }
            if(user != null && user.Password == login.Password)
            {
                var claims = new List<Claim>
                {
                  new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                  new Claim(ClaimTypes.Name, user.UserName)
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(Configuration.GetSection("SigningKey").Value));

                var token = new JwtSecurityToken(
                  issuer: "http://www.security.org",
                  audience: "http://www.security.org",
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(20),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo
                };
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerNotFound);
            }
        }
    }
}
