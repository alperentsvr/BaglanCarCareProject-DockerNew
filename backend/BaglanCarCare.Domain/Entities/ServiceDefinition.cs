using BaglanCarCare.Domain.Common;
using System.Collections.Generic;

namespace BaglanCarCare.Domain.Entities
{
    public class ServiceDefinition : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string IncludedParts { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // BU SATIR EKSİKTİ, İLİŞKİ İÇİN GEREKLİ:
        public ICollection<ServiceTransaction> ServiceTransactions { get; set; } = new List<ServiceTransaction>();
    }
}