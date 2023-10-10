using MenuKortV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Data
{
    public interface ILoginService
    {
        Task<LoginResponse> Authenticate(LoginRequest loginRequest);
    }
}
