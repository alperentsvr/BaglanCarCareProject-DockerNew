using BaglanCarCare.Domain.Common;
using System.Collections.Generic;

namespace BaglanCarCare.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public string? Color { get; set; }

        // DİKKAT: Burası int olmalı. Eğer string ise 'int Year' yap.
        public int Year { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ServiceTransaction> ServiceTransactions { get; set; }
    }
}