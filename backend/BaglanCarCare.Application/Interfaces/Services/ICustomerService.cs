using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface ICustomerService { Task<ServiceResponse<List<CustomerDto>>> GetAllAsync(string? s = null); Task<ServiceResponse<int>> CreateAsync(CreateCustomerDto r); Task<ServiceResponse<bool>> UpdateAsync(UpdateCustomerDto r); Task<ServiceResponse<bool>> DeleteAsync(int id); }
}