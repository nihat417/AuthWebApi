using Auth.Application.DTOs;

namespace Auth.Application.Services.Interfaces
{
    public interface ILoginRegister
    {
        Task<bool> Register(UserDTO request);
        Task<string> Login(UserDTO request);
    }
}
