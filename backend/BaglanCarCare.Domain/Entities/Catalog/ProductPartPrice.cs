using BaglanCarCare.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaglanCarCare.Domain.Entities.Catalog
{
    public class ProductPartPrice : BaseEntity
    {
        public string PartName { get; set; } // Örn: "Kaput", "Sol Çamurluk", "Komple Araç"

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Örn: 3000

        public bool IsExtra { get; set; } = false; // Senin istediğin bool kontrolü (Ek parça mı?)

        // İlişkiler
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
    }
}