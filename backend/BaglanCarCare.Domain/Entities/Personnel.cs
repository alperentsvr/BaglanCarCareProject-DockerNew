using BaglanCarCare.Domain.Common;
using System;
using System.Collections.Generic;

namespace BaglanCarCare.Domain.Entities
{
    // İşletmede çalışan personel
    public class Personnel : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; } // Örn: Usta, Kalfa
        public decimal Salary { get; set; }  // Maaş Bilgisi
        public DateTime StartDate { get; set; }

        // İlişki: Bir personelin yaptığı işlemler listesi
        public ICollection<ServiceTransaction> ServiceTransactions { get; set; }
    }
}
