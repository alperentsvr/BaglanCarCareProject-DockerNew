using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace BaglanCarCare.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _s; public AuthController(IAuthService s) { _s = s; }
        [HttpPost("login")] public async Task<IActionResult> Login(LoginDto r) => Ok(await _s.LoginAsync(r));
        [HttpPost("register")] public async Task<IActionResult> Register(RegisterDto r) => Ok(await _s.RegisterAsync(r));
    }
}