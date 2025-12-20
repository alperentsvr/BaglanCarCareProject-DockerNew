using BaglanCarCare.Domain.Common;

namespace BaglanCarCare.Domain.Entities
{
    public class ServiceTransactionItem : BaseEntity
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // YENİ: Parçaları veritabanında uzun bir yazı olarak tutacağız
        // Örn: "Kaput, Tavan, Bagaj"
        public string SelectedParts { get; set; }

        public int ServiceTransactionId { get; set; }
        public ServiceTransaction ServiceTransaction { get; set; }
    }
}