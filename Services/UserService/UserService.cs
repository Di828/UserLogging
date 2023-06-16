using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using UserLogging.DbData;
using UserLogging.Models.User;

namespace UserLogging.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> Login(UserDto loginDto)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username);
            if (user == null)
            {
                return new AuthResponse() { StatusCode = 404, Message = "User with this login not found", JwtToken = null };
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return new AuthResponse() { StatusCode = 401, Message = "Password is incorrect", JwtToken = null };
            }

            return CreateResponseWithJwtToken(user);
        }

        public async Task<AuthResponse> Register (UserDto registrationDto)
        {
            if (await AlreadyExist(registrationDto.Username))
            {
                return new AuthResponse() { StatusCode = 409, Message = "User with this login already exist", JwtToken = null };
            }

            User user = new User();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);

            user.Username = registrationDto.Username;
            user.PasswordHash = passwordHash;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreateResponseWithJwtToken(user);
        }

        private async Task<bool> AlreadyExist (string username)
        {
            return (await _context.Users.FirstOrDefaultAsync(x => x.Username == username)) != null;
        }

        private AuthResponse CreateResponseWithJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse() { StatusCode = 200, JwtToken = jwtToken };
        }
    }
}
