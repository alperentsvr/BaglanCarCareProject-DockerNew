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
    public class DashboardManager : IDashboardService
    {
        private readonly IGenericRepository<Customer> _cRepo; private readonly IGenericRepository<Vehicle> _vRepo; private readonly IGenericRepository<ServiceTransaction> _tRepo;
        public DashboardManager(IGenericRepository<Customer> c, IGenericRepository<Vehicle> v, IGenericRepository<ServiceTransaction> t) { _cRepo = c; _vRepo = v; _tRepo = t; }
        public async Task<ServiceResponse<DashboardStatsDto>> GetStatsAsync()
        {
            var c = await _cRepo.GetAllAsync(); var v = await _vRepo.GetAllAsync(); var t = await _tRepo.GetAllAsync();
            var s = new DashboardStatsDto { TotalCustomers = c.Count, TotalVehicles = v.Count, PendingTransactions = t.Count(x => x.Status != TransactionStatus.Completed && x.Status != TransactionStatus.Cancelled), MonthlyIncome = t.Where(x => x.TransactionDate.Month == DateTime.UtcNow.Month && x.PaymentStatus == PaymentStatus.Paid).Sum(x => x.TotalPrice) };
            return new ServiceResponse<DashboardStatsDto>(s);
        }
    }
}