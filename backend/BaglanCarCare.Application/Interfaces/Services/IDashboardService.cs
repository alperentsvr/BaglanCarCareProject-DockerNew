using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Interfaces.Services
{
    public interface IDashboardService { Task<ServiceResponse<DashboardStatsDto>> GetStatsAsync(); }
}