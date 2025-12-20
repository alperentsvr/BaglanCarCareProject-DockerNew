using BaglanCarCare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace BaglanCarCare.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _s; public DashboardController(IDashboardService s) { _s = s; }
        [HttpGet("ozet")] public async Task<IActionResult> Stats() => Ok(await _s.GetStatsAsync());
    }
}