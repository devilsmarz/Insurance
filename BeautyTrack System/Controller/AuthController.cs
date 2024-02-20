using BeautyTrack_System.API.Models;
using BeautyTrack_System.Mapper;
using BeautyTrack_System.Models;
using BeautyTrackSystem.BLL.Models;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTrack_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            ServiceResponse<UserModel> response = await _authService.Register(MapperInitializer.GetRegisterModel(registerViewModel));
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ServiceResponse<JwtModel> response = await _authService.Login(MapperInitializer.GetLoginModel(loginViewModel));
            return Ok(response);
        }
    }
}
