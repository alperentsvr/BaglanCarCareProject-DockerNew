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
        private readonly IDeletionRequestService _deletionRequestService;

        public OrdersController(IOrderService service, IDeletionRequestService deletionRequestService)
        {
            _service = service;
            _deletionRequestService = deletionRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllOrdersAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto request) => Ok(await _service.CreateOrderAsync(request));

        [HttpPut("guncelle")]
        public async Task<IActionResult> Update(UpdateOrderDto request) => Ok(await _service.UpdateOrderDetailsAsync(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string? note = null)
        {
            if (User.IsInRole("Admin"))
            {
                return Ok(await _service.DeleteOrderAsync(id));
            }
            else
            {
                var username = User.Identity?.Name ?? "Bilinmiyor";
                var req = new CreateDeletionRequestDto 
                { 
                    TargetEntityName = "Order", 
                    TargetId = id, 
                    Note = !string.IsNullOrEmpty(note) ? note : "Personel talebi",
                    RequestType = "OrderDelete",
                    Details = $"Sipariş #{id} silme talebi"
                };
                // 0 as RequesterId placeholder (Gerçek sistemde User.Id olmalı)
                return Ok(await _deletionRequestService.CreateRequestAsync(req, 0, username));
            }
        }

        [HttpPost("{id}/request-service-delete")]
        public async Task<IActionResult> RequestServiceDelete(int id, [FromBody] dynamic data)
        {
            var username = User.Identity?.Name ?? "Bilinmiyor";
            string serviceName = data.GetProperty("serviceName").ToString();
            string note = data.GetProperty("note").ToString();
            
            var req = new CreateDeletionRequestDto 
            { 
                TargetEntityName = "Order", 
                TargetId = id, 
                Note = note,
                RequestType = "ServiceDelete",
                Details = $"Hizmet Silme: {serviceName}"
            };
            return Ok(await _deletionRequestService.CreateRequestAsync(req, 0, username));
        }

        [HttpPost("{id}/request-price-change")]
        public async Task<IActionResult> RequestPriceChange(int id, [FromBody] dynamic data)
        {
            var username = User.Identity?.Name ?? "Bilinmiyor";
            string serviceName = data.GetProperty("serviceName").ToString();
            string oldPrice = data.GetProperty("oldPrice").ToString();
            string newPrice = data.GetProperty("newPrice").ToString();
            string note = data.GetProperty("note").ToString();

            var req = new CreateDeletionRequestDto 
            { 
                TargetEntityName = "Order", 
                TargetId = id, 
                Note = note,
                RequestType = "PriceChange",
                Details = $"Fiyat Değişimi: {serviceName} ({oldPrice} -> {newPrice})"
            };
            return Ok(await _deletionRequestService.CreateRequestAsync(req, 0, username));
        }

        [HttpGet("ara/{text}")]
        public async Task<IActionResult> Search(string text) => Ok(await _service.SearchByPhoneOrPlateAsync(text));
    }
}