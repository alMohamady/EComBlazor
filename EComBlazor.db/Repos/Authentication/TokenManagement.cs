using EComBlazor.db.Base.Authentication;
using EComBlazor.db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Repos.Authentication
{
    public class TokenManagement(AppDbContext context, IConfiguration config) : ITokenManagement
    {
        public async Task<int> AddRefreshToken(string userId, string refreshToken)
        {
            context.RefreshTokens.Add(new Entities.Identity.RefreshToken()
            {
                UserId = userId,
                Token = refreshToken
            });
            return await context.SaveChangesAsync();
        }

        public string GenrateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireation = DateTime.UtcNow.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: expireation,
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetRefreshToken()
        {
            const int byteSize = 64; byte[] randomBytes = new byte[byteSize] ;
            using(RandomNumberGenerator  rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        public List<Claim> GetUserClamesFromToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(email);
            if (jwtToken != null)
            {
                return jwtToken.Claims.ToList();
            }
            else
            {
                return [];
            }
        }

        public async Task<string> GetUserIdByRefreshToken(string refreshToken)
        {
            return (await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken))!.UserId;
        }

        public async Task<int> UpdateRefreshToken(string userId, string refreshToken)
        {
            var user = await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
            if (user == null) return -1; 
            user.Token = refreshToken;
            return await context.SaveChangesAsync();
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken)
        {
            var user = await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
            return user != null;
        }
    }
}
