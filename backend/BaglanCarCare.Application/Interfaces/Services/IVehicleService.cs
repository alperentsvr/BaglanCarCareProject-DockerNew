using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface IVehicleService { Task<ServiceResponse<List<VehicleDto>>> GetAllAsync(string? s = null); Task<ServiceResponse<int>> CreateAsync(CreateVehicleDto r); Task<ServiceResponse<bool>> UpdateAsync(UpdateVehicleDto r); Task<ServiceResponse<bool>> DeleteAsync(int id); Task<ServiceResponse<List<VehicleDto>>> GetByCustomerAsync(int cid); }
}