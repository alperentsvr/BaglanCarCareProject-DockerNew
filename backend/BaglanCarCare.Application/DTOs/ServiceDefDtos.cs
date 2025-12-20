namespace BaglanCarCare.Application.DTOs
{
    // Hizmet Ekleme Modeli
    public class CreateServiceDefDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string IncludedParts { get; set; }
        public decimal Price { get; set; } // Fiyat alanı da ekli olsun
    }

    // Hizmet Listeleme Modeli
    public class ServiceDefDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string IncludedParts { get; set; }
        public decimal Price { get; set; }
    }
}