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
    public class PersonnelManager : IPersonnelService
    {
        private readonly IGenericRepository<Personnel> _repo; private readonly IMapper _map;
        public PersonnelManager(IGenericRepository<Personnel> r, IMapper m) { _repo = r; _map = m; }
        public async Task<ServiceResponse<int>> CreateAsync(CreatePersonnelDto r) { var e = _map.Map<Personnel>(r); await _repo.AddAsync(e); return new ServiceResponse<int>(e.Id); }
        public async Task<ServiceResponse<bool>> DeleteAsync(int id) { var e = await _repo.GetByIdAsync(id); if (e == null) return new ServiceResponse<bool>("Yok", false); await _repo.DeleteAsync(e); return new ServiceResponse<bool>(true); }
        public async Task<ServiceResponse<bool>> UpdateAsync(UpdatePersonnelDto r) { var e = await _repo.GetByIdAsync(r.Id); if (e == null) return new ServiceResponse<bool>("Yok", false); e.FirstName = r.FirstName; e.LastName = r.LastName; e.Position = r.Position; e.Salary = r.Salary; await _repo.UpdateAsync(e); return new ServiceResponse<bool>(true); }
        public async Task<ServiceResponse<List<PersonnelDto>>> GetAllAsync(string? s = null) { var d = await _repo.GetAllAsync(); if (!string.IsNullOrEmpty(s)) d = d.Where(x => x.FirstName.Contains(s, StringComparison.OrdinalIgnoreCase)).ToList(); return new ServiceResponse<List<PersonnelDto>>(_map.Map<List<PersonnelDto>>(d)); }
    }
}