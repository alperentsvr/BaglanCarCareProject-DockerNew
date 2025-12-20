using BaglanCarCare.Domain.Common;

namespace BaglanCarCare.Domain.Entities
{
    // Olex Films Malzemeleri (Fiyat bilgisi kaldırıldı, teknik detaylar var)
    public class Material : BaseEntity
    {
        public string Name { get; set; }        // Örn: Olex Pro-Bond
        public string Category { get; set; }    // Örn: PPF
        public string QualityGrade { get; set; } // Örn: Premium Plus
        public int WarrantyYears { get; set; }   // Garanti Yılı
        public string Thickness { get; set; }    // Kalınlık
        public string Description { get; set; }  // Açıklama
    }
}