using BaglanCarCare.Domain.Common;
using System.Collections.Generic;

namespace BaglanCarCare.Domain.Entities.Catalog
{
    public class ProductVariant : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Örn: "Parlak Seri"
        public string ThicknessCode { get; set; } = string.Empty; // Örn: "190"

        // Yeni Mantık: Alt Parça (Kaput, Tavan vb.) var mı?
        public bool HasSubParts { get; set; } = false;

        // Alt parça yoksa fiyat buraya girilir (Örn: Cam filmi tek fiyat)
        public decimal VariantPrice { get; set; } = 0;

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<ProductPartPrice> PartPrices { get; set; }
    }
}