using System;
using System.Collections.Generic;

namespace BaglanCarCare.Application.DTOs
{
    // Hata veren sınıf buydu:
    public class TransactionItemDto
    {
        public string? Category { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public List<string>? SelectedParts { get; set; }
    }

    public class CreateTransactionDto
    {
        public string? Description { get; set; }
        public int VehicleId { get; set; }
        public List<int> PersonnelIds { get; set; } = new List<int>();
        public DateTime AppointmentDate { get; set; }
        public int? ServiceDefinitionId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<TransactionItemDto> Items { get; set; } = new List<TransactionItemDto>();
    }

    public class UpdateTransactionDetailsDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class UpdateTransactionStatusDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }

    public class ServiceTransactionDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? VehiclePlate { get; set; }
        public string? ServiceName { get; set; } // Mapping hatası için gerekli
        public string? PersonnelNames { get; set; } // Mapping hatası için gerekli
        public DateTime AppointmentDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime Date { get; set; }
    }
}