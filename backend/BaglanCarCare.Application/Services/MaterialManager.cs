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
    public class MaterialManager : IMaterialService
    {
        private readonly IGenericRepository<Material> _repo; private readonly IMapper _map;
        public MaterialManager(IGenericRepository<Material> r, IMapper m) { _repo = r; _map = m; }
        public async Task<ServiceResponse<int>> CreateAsync(CreateMaterialDto r) { var e = _map.Map<Material>(r); await _repo.AddAsync(e); return new ServiceResponse<int>(e.Id); }
        public async Task<ServiceResponse<bool>> DeleteAsync(int id) { var e = await _repo.GetByIdAsync(id); if (e == null) return new ServiceResponse<bool>("Yok", false); await _repo.DeleteAsync(e); return new ServiceResponse<bool>(true); }
        public async Task<ServiceResponse<bool>> UpdateAsync(UpdateMaterialDto r) { var e = await _repo.GetByIdAsync(r.Id); if (e == null) return new ServiceResponse<bool>("Yok", false); e.Name = r.Name; e.Category = r.Category; e.QualityGrade = r.QualityGrade; e.WarrantyYears = r.WarrantyYears; e.Thickness = r.Thickness; e.Description = r.Description; await _repo.UpdateAsync(e); return new ServiceResponse<bool>(true); }
        public async Task<ServiceResponse<List<MaterialDto>>> GetAllAsync() { var d = await _repo.GetAllAsync(); return new ServiceResponse<List<MaterialDto>>(_map.Map<List<MaterialDto>>(d)); }
    }
}