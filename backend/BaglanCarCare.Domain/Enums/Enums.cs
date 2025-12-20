namespace BaglanCarCare.Domain.Enums
{
    // İşlemin ödenip ödenmediği durumu
    public enum PaymentStatus { Unpaid = 1, Paid = 2 }

    // İşlemin süreci (Bekliyor -> İşlemde -> Bitti)
    public enum TransactionStatus { Pending = 1, InProgress = 2, Completed = 3, Cancelled = 4 }

    // Ödeme Yöntemi (Muhasebe takibi için)
    public enum PaymentMethod
    {
        None = 0,           // Belirtilmedi
        Cash = 1,           // Nakit
        CreditCard = 2,     // Kredi Kartı
        EFT_Transfer = 3    // Havale / EFT
    }
}