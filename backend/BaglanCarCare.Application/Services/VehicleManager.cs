using AutoMapper;
using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Repositories;
using BaglanCarCare.Application.Interfaces.Services;
using BaglanCarCare.Application.Wrappers;
using BaglanCarCare.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BaglanCarCare.Application.Services
{
    public class VehicleManager : IVehicleService
    {
        private readonly IGenericRepository<Vehicle> _repo; private readonly IMapper _map;
        public VehicleManager(IGenericRepository<Vehicle> r, IMapper m) { _repo = r; _map = m; }
        public async Task<ServiceResponse<int>> CreateAsync(CreateVehicleDto r) { var e = _map.Map<Vehicle>(r); await _repo.AddAsync(e); return new ServiceResponse<int>(e.Id); }
        public async Task<ServiceResponse<bool>> DeleteAsync(int id) { var e = await _repo.GetByIdAsync(id); if (e == null) return new ServiceResponse<bool>("Yok", false); await _repo.DeleteAsync(e); return new ServiceResponse<bool>(true); }
        public async Task<ServiceResponse<bool>> UpdateAsync(UpdateVehicleDto r) { var e = await _repo.GetByIdAsync(r.Id); if (e == null) return new ServiceResponse<bool>("Yok", false); e.PlateNumber = r.PlateNumber; e.Brand = r.Brand; e.Model = r.Model; await _repo.UpdateAsync(e); return new ServiceResponse<bool>(true); }
        public async Task<ServiceResponse<List<VehicleDto>>> GetByCustomerAsync(int cid) { var d = await _repo.GetAsync(x => x.CustomerId == cid); return new ServiceResponse<List<VehicleDto>>(_map.Map<List<VehicleDto>>(d)); }
        public async Task<ServiceResponse<List<VehicleDto>>> GetAllAsync(string? s = null) { var d = await _repo.GetAllAsync(); if (!string.IsNullOrEmpty(s)) d = d.Where(x => x.PlateNumber.Contains(s, StringComparison.OrdinalIgnoreCase)).ToList(); return new ServiceResponse<List<VehicleDto>>(_map.Map<List<VehicleDto>>(d)); }
    }
}