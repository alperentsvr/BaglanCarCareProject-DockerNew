using System;

namespace BaglanCarCare.Application.DTOs
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; } // 1: Gelir, 0: Gider (Frontend için int dönüyoruz)
        public DateTime Date { get; set; }
    }

    public class CreateExpenseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; } // 1: Gelir, 0: Gider
        public DateTime Date { get; set; }
    }

    public class UpdateExpenseDto : CreateExpenseDto
    {
        public int Id { get; set; }
    }
}