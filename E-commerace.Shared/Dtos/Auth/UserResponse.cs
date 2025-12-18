using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Shared.Dtos.Auth
{
    public class UserResponse
    {
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
