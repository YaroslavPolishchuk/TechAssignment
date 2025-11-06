using Microsoft.AspNetCore.Mvc;
using TechAssignment.TokenValidationService.Models;
using TechAssignment.TokenValidationService.Services;

namespace TechAssignment.TokenValidationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {            
            if (!_authService.ValidateCredentials(request.Username, request.Password))
                return Unauthorized("Invalid username or password");

            return Ok(new { Message = "Login successful" });
        }
    }
}
