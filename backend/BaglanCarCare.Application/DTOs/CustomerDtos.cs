namespace BaglanCarCare.Application.DTOs
{
    public class CreateCustomerDto { public string FirstName { get; set; } public string LastName { get; set; } public string PhoneNumber { get; set; } public string? Email { get; set; } }
    public class UpdateCustomerDto { public int Id { get; set; } public string FirstName { get; set; } public string LastName { get; set; } public string PhoneNumber { get; set; } public string? Email { get; set; } }
    public class CustomerDto { public int Id { get; set; } public string FullName { get; set; } public string PhoneNumber { get; set; } }
}