using AutoMapper;
using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Repositories;
using BaglanCarCare.Application.Interfaces.Services;
using BaglanCarCare.Application.Wrappers;
using BaglanCarCare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Services
{
    public class ServiceDefManager : IServiceDefService
    {
        private readonly IGenericRepository<ServiceDefinition> _repo; private readonly IMapper _map;
        public ServiceDefManager(IGenericRepository<ServiceDefinition> r, IMapper m) { _repo = r; _map = m; }
        public async Task<ServiceResponse<int>> CreateAsync(CreateServiceDefDto r) { var e = _map.Map<ServiceDefinition>(r); await _repo.AddAsync(e); return new ServiceResponse<int>(e.Id); }
        public async Task<ServiceResponse<List<ServiceDefDto>>> GetAllAsync() { var d = await _repo.GetAllAsync(); return new ServiceResponse<List<ServiceDefDto>>(_map.Map<List<ServiceDefDto>>(d)); }
    }
}