using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaglanCarCare.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            _service = service;
        }

        // --- KATEGORİ ---
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories() => Ok(await _service.GetAllCategoriesAsync());

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto req) => Ok(await _service.CreateCategoryAsync(req));

        [HttpPut("categories")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto req) => Ok(await _service.UpdateCategoryAsync(req));

        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> DeleteCategory(int id) => Ok(await _service.DeleteCategoryAsync(id));


        // --- ÜRÜN (LEVEL 1) ---
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts() => Ok(await _service.GetAllProductsAsync());

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id) => Ok(await _service.GetProductByIdAsync(id));

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(CreateProductDto req) => Ok(await _service.CreateProductAsync(req));

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto req) => Ok(await _service.UpdateProductAsync(req));

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok(await _service.DeleteProductAsync(id));


        // --- VARYANT (LEVEL 2) ---
        [HttpPost("variants")]
        public async Task<IActionResult> CreateVariant(CreateVariantDto req) => Ok(await _service.CreateVariantAsync(req));

        [HttpPut("variants")]
        public async Task<IActionResult> UpdateVariant(UpdateVariantDto req) => Ok(await _service.UpdateVariantAsync(req));

        [HttpDelete("variants/{id}")]
        public async Task<IActionResult> DeleteVariant(int id) => Ok(await _service.DeleteVariantAsync(id));


        // --- PARÇA (LEVEL 3) ---
        [HttpPost("parts")]
        public async Task<IActionResult> CreatePart(CreatePartPriceDto req) => Ok(await _service.CreatePartPriceAsync(req));

        [HttpPut("parts")]
        public async Task<IActionResult> UpdatePart(UpdatePartPriceDto req) => Ok(await _service.UpdatePartPriceAsync(req));

        [HttpDelete("parts/{id}")]
        public async Task<IActionResult> DeletePart(int id) => Ok(await _service.DeletePartPriceAsync(id));
    }
}