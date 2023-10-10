using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
