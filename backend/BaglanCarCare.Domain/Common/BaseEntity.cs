using System;

namespace BaglanCarCare.Domain.Common
{
    /// <summary>
    /// Tüm veritabanı tablolarının (Entity) miras alacağı temel sınıf.
    /// Kod tekrarını önlemek için ID ve Tarih gibi ortak alanları burada tutuyoruz.
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; } // Birincil Anahtar (Primary Key)
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Kayıt oluşturulma zamanı

        // Veriyi fiziksel olarak silmek yerine gizlemek için (Soft Delete)
        public bool IsDeleted { get; set; } = false;
    }
}