using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaglanCarCare.WebApi.Controllers
{
    [Authorize(Roles = "Admin")] // Bu kayıtları sadece Admin görmeli
    [ApiController]
    [Route("api/ek-muhasebe")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseDto request)
        {
            return Ok(await _service.CreateAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateExpenseDto request)
        {
            return Ok(await _service.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}