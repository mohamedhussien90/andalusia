using static Assignment_8.Models.AuthDTOs;

namespace Assignment_8.Services
{
    public interface IAuthService
    {
        bool Register(RegisterRequest request);
        string? Login(LoginRequest request);
    }
}
