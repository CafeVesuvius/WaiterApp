using MenuKortV1.Model;

namespace MenuKortV1.Data
{
    public interface ILoginService
    {
        Task<LoginResponse> Authenticate(LoginRequest loginRequest);
    }
}
