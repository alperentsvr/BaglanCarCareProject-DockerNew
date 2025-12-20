using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace BaglanCarCare.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/muhasebe")]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingService _s; public AccountingController(IAccountingService s) { _s = s; }
        [HttpGet("rapor")] public async Task<IActionResult> GetReport([FromQuery] DateTime start, [FromQuery] DateTime end) => Ok(await _s.GetReportAsync(start, end));
        [HttpPost("odeme-guncelle")] public async Task<IActionResult> UpdatePayment(UpdatePaymentDto r) => Ok(await _s.UpdatePaymentAsync(r));
    }
}