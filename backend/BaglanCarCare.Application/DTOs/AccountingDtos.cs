using System;
namespace BaglanCarCare.Application.DTOs
{
    public class UpdatePaymentDto { public int TransactionId { get; set; } public bool IsPaid { get; set; } public int PaymentMethodId { get; set; } }
    public class IncomeReportDto { public DateTime StartDate { get; set; } public DateTime EndDate { get; set; } public decimal TotalIncome { get; set; } public decimal PendingIncome { get; set; } }
}