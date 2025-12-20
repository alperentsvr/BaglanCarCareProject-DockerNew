using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface IAccountingService { Task<ServiceResponse<IncomeReportDto>> GetReportAsync(DateTime s, DateTime e); Task<ServiceResponse<bool>> UpdatePaymentAsync(UpdatePaymentDto r); }
}