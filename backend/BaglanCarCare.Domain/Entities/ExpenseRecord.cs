using BaglanCarCare.Domain.Common;
using System;

namespace BaglanCarCare.Domain.Entities
{
    public class ExpenseRecord : BaseEntity
    {
        public string Title { get; set; }       // Başlık (Örn: Kira, Elektrik, Bahşiş)
        public string Description { get; set; } // Detaylı Açıklama
        public decimal Amount { get; set; }     // Tutar

        // 1: Gelir (Income), 0: Gider (Expense)
        // Veritabanında bool tutmak daha performanslıdır (True: Gelir, False: Gider)
        // Ancak senin isteğin üzerine integer gibi davranan bir mantık kuracağız.
        public bool IsIncome { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}