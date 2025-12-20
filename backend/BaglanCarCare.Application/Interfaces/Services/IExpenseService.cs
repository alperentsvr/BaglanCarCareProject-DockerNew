using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface IExpenseService
    {
        Task<ServiceResponse<List<ExpenseDto>>> GetAllAsync();
        Task<ServiceResponse<int>> CreateAsync(CreateExpenseDto request);
        Task<ServiceResponse<bool>> UpdateAsync(UpdateExpenseDto request);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}