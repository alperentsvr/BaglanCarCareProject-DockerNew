using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Repositories;
using BaglanCarCare.Application.Interfaces.Services;
using BaglanCarCare.Application.Wrappers;
using BaglanCarCare.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Services
{
    public class AuthManager : IAuthService
    {
        private readonly IGenericRepository<User> _repo; private readonly IConfiguration _config;
        public AuthManager(IGenericRepository<User> repo, IConfiguration config) { _repo = repo; _config = config; }
        public async Task<ServiceResponse<TokenDto>> LoginAsync(LoginDto r)
        {
            var user = (await _repo.GetAsync(u => u.Username == r.Username)).FirstOrDefault();
            if (user == null || user.PasswordHash != r.Password) return new ServiceResponse<TokenDto>("Hatalı giriş", false);
            var secretKey = _config["JwtSettings:SecretKey"] ?? "default_secret_key_for_dev_only";
            var key = Encoding.ASCII.GetBytes(secretKey);
            var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username), new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            }));
            return new ServiceResponse<TokenDto>(new TokenDto { Token = token, Role = user.Role, FullName = user.FullName });
        }
        public async Task<ServiceResponse<int>> RegisterAsync(RegisterDto r) { var u = new User { Username = r.Username, PasswordHash = r.Password, FullName = r.FullName, Role = r.Role }; await _repo.AddAsync(u); return new ServiceResponse<int>(u.Id); }
    }
}