using E_commerace.Shared.Dtos.Auth;
using E_Commerace.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_commerace.Presentation.Api.Controller
{
    public class AuthController : APIBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.LoginAsync(loginRequest);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var result = await _authService.RegisterAsync(registerRequest);
            return Ok(result);
        }
    }
}
