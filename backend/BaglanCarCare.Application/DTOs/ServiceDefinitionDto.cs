// Dosyanýn en üstüne ekleyin:
using BaglanCarCare.Application.DTOs;

// Eðer `ServiceDefinitionDto` projenizde yoksa, aþaðýdaki gibi bir DTO ekleyin:
namespace BaglanCarCare.Application.DTOs
{
    public class ServiceDefinitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string IncludedParts { get; set; }
        public decimal Price { get; set; }
    }
}