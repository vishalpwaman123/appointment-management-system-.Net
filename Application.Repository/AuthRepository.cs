using Application.Domain;
using Application.Domain.Context;
using Application.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly ApplicationDBContext _dbContext;
        public AuthRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            try
            {
                var result = await _dbContext.User
                    .FirstOrDefaultAsync(x => (x.Email.ToLower() == request.Email.ToLower()) &&
                                                            x.Password == request.Password
                                                            );

                if (result is null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Credential";
                    return response;
                }

                result.Password = string.Empty;
                response.Token = GenerateJwtToken(result);
                response.Data = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private string GenerateJwtToken(User request)
        {
            try
            {
                // Define token parameters
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("P983vWV2urVSWYvOojywVhiafxcRW+wDnHYSynp2f7M=\r\n\r\n"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Define claims (e.g., for user identity)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email,  request.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Create the token
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:7040",    // Issuer
                    audience: "http://localhost:7040",  // Audience
                    claims: claims,              // User claims
                    expires: DateTime.Now.AddHours(1), // Expiration time
                    signingCredentials: credentials // Credentials for signing the token
                );

                // Serialize the token to a string
                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
