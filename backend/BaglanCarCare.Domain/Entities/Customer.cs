using BaglanCarCare.Domain.Common;
using System.Collections.Generic;

namespace BaglanCarCare.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}