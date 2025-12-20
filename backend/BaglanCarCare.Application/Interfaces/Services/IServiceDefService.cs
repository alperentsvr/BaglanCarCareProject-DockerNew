using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaglanCarCare.Application.Interfaces.Services;

namespace BaglanCarCare.Application.Interfaces.Services // Namespace burası olmalı
{
    public interface IServiceDefService
    {
        Task<ServiceResponse<List<ServiceDefDto>>> GetAllAsync();
        Task<ServiceResponse<int>> CreateAsync(CreateServiceDefDto request);
    }
}