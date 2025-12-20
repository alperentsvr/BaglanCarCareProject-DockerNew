using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Repositories;
using BaglanCarCare.Application.Interfaces.Services;
using BaglanCarCare.Application.Wrappers;
using BaglanCarCare.Domain.Entities;
using BaglanCarCare.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Services
{
    public class AccountingManager : IAccountingService
    {
        private readonly IGenericRepository<ServiceTransaction> _repo;
        public AccountingManager(IGenericRepository<ServiceTransaction> r) { _repo = r; }
        public async Task<ServiceResponse<IncomeReportDto>> GetReportAsync(DateTime s, DateTime e)
        {
            var d = await _repo.GetAsync(x => x.TransactionDate >= s && x.TransactionDate <= e);
            var r = new IncomeReportDto { StartDate = s, EndDate = e, TotalIncome = d.Where(x => x.PaymentStatus == PaymentStatus.Paid).Sum(x => x.TotalPrice), PendingIncome = d.Where(x => x.PaymentStatus == PaymentStatus.Unpaid).Sum(x => x.TotalPrice) };
            return new ServiceResponse<IncomeReportDto>(r);
        }
        public async Task<ServiceResponse<bool>> UpdatePaymentAsync(UpdatePaymentDto r)
        {
            var t = await _repo.GetByIdAsync(r.TransactionId); if (t == null) return new ServiceResponse<bool>("Yok", false);
            t.PaymentStatus = r.IsPaid ? PaymentStatus.Paid : PaymentStatus.Unpaid;
            t.PaymentMethod = r.IsPaid ? (PaymentMethod)r.PaymentMethodId : PaymentMethod.None;
            await _repo.UpdateAsync(t); return new ServiceResponse<bool>(true);
        }
    }
}