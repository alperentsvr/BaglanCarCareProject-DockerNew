using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaglanCarCare.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/siparis")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllOrdersAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto request) => Ok(await _service.CreateOrderAsync(request));

        [HttpPut("guncelle")]
        public async Task<IActionResult> Update(UpdateOrderDto request) => Ok(await _service.UpdateOrderDetailsAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteOrderAsync(id));

        [HttpGet("ara/{text}")]
        public async Task<IActionResult> Search(string text) => Ok(await _service.SearchByPhoneOrPlateAsync(text));
    }
}