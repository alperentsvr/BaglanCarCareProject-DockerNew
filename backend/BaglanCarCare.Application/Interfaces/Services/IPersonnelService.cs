using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface IPersonnelService { Task<ServiceResponse<List<PersonnelDto>>> GetAllAsync(string? search = null); Task<ServiceResponse<int>> CreateAsync(CreatePersonnelDto r); Task<ServiceResponse<bool>> UpdateAsync(UpdatePersonnelDto r); Task<ServiceResponse<bool>> DeleteAsync(int id); }
}