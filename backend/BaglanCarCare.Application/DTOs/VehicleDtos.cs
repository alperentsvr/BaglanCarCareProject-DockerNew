namespace BaglanCarCare.Application.DTOs
{
    public class CreateVehicleDto { public string PlateNumber { get; set; } public string Brand { get; set; } public string Model { get; set; } public int CustomerId { get; set; } }
    public class UpdateVehicleDto { public int Id { get; set; } public string PlateNumber { get; set; } public string Brand { get; set; } public string Model { get; set; } }
    public class VehicleDto { public int Id { get; set; } public string PlateNumber { get; set; } public string BrandModel { get; set; } public string CustomerName { get; set; } }
}