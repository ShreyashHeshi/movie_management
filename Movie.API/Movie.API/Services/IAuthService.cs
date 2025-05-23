using Movie.API.DTOs.User;

namespace Movie.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(UserRegisterRequest request);
        Task<AuthResponse> LoginAsync(UserLoginRequest request);
    }
}
