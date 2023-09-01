using Auth.Application.DTOs;
using Auth.Application.Services.Interfaces;
using Auth.Core.Entities;
using Auth.Infrastructure.Persistence.Data;

namespace Auth.Application.Services
{
    public class LoginRegisterService : ILoginRegister
    {
        private readonly AppDbContext context;

        public LoginRegisterService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Login(UserDTO request)
        {
            var user = context.Users.FirstOrDefault(us => us.UserName == request.UserName);
            if (user == null)
            {
                throw new Exception("username is wrong");
            }
            if(!PasswordHash.VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt))
            {
                throw new Exception("wrong password");
            }
            string token = JWTTokenService.CreateToken(user);
            return token;
        }

        public async Task<bool> Register(UserDTO request)
        {
            if(context.Users.Any(us => us.UserName==request.UserName))
            {
                throw new Exception("username is already taken");
            }
            PasswordHash.CreatePasswordHash(request.Password,out byte[] passHash,out byte[] passSalt);
            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                PasswordHash = passHash,
                PasswordSalt = passSalt,
                Email = request.Email,
            };
            
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
