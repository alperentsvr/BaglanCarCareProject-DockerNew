using BaglanCarCare.Domain.Common;

namespace BaglanCarCare.Domain.Entities
{
    // Bir işlemin alt kalemleri (Örn: Kaput - 3000 TL, Ön Cam - 2000 TL)
    public class TransactionDetail : BaseEntity
    {
        public int ServiceTransactionId { get; set; }
        public ServiceTransaction ServiceTransaction { get; set; }

        public string Category { get; set; } // Örn: "PPF", "Cam Filmi", "Yıkama"
        public string ProductName { get; set; } // Örn: "OLEX Carat Series"
        public string? Specification { get; set; } // Örn: "190 Mikron" veya "3 Yıl Garanti"
        public string ItemName { get; set; } // Örn: "Kaput", "Sol Ön Cam" veya "Motor Yıkama"
        public decimal Price { get; set; } // O parçanın fiyatı
    }
}