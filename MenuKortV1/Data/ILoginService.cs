using MenuKortV1.Model;

namespace MenuKortV1.Data
{
    public interface ILoginService
    {
        // Interface for login system
        Task<LoginResponse> Authenticate(LoginRequest loginRequest);
    }
}
