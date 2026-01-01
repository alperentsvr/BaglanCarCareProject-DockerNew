using BaglanCarCare.Domain.Common;

namespace BaglanCarCare.Domain.Entities
{
    // Sisteme giriş yapacak yetkili kullanıcılar (Admin ve Personel)
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Şifreler hashlenmiş tutulur
        public string FullName { get; set; }
        public string Role { get; set; } // Yetki Seviyesi: "Admin" veya "Staff"
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockoutEnd { get; set; }
    }
}