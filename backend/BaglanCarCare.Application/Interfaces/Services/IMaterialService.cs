using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface IMaterialService { Task<ServiceResponse<List<MaterialDto>>> GetAllAsync(); Task<ServiceResponse<int>> CreateAsync(CreateMaterialDto r); Task<ServiceResponse<bool>> UpdateAsync(UpdateMaterialDto r); Task<ServiceResponse<bool>> DeleteAsync(int id); }
}