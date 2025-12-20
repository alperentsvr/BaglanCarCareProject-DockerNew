using AutoMapper;
using BaglanCarCare.Application.DTOs;
using BaglanCarCare.Application.Interfaces.Repositories;
using BaglanCarCare.Application.Interfaces.Services;
using BaglanCarCare.Application.Wrappers;
using BaglanCarCare.Domain.Entities;
using System.Collections.Generic;
using System.Linq; // OrderBy için gerekli
using System.Threading.Tasks;

namespace BaglanCarCare.Application.Services
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IGenericRepository<ExpenseRecord> _repo;
        private readonly IMapper _map;

        public ExpenseManager(IGenericRepository<ExpenseRecord> repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        public async Task<ServiceResponse<List<ExpenseDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            // Tarihe göre sırala (En yeni en üstte)
            var sortedData = data.OrderByDescending(x => x.Date).ToList();
            var dtos = _map.Map<List<ExpenseDto>>(sortedData);
            return new ServiceResponse<List<ExpenseDto>>(dtos);
        }

        public async Task<ServiceResponse<int>> CreateAsync(CreateExpenseDto r)
        {
            var entity = _map.Map<ExpenseRecord>(r);
            // Frontend'den gelen tarihi UTC'ye çevir, yoksa hata alabilirsin
            entity.Date = entity.Date.ToUniversalTime();
            await _repo.AddAsync(entity);
            return new ServiceResponse<int>(entity.Id);
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(UpdateExpenseDto r)
        {
            var entity = await _repo.GetByIdAsync(r.Id);
            if (entity == null) return new ServiceResponse<bool>("Kayıt bulunamadı", false);

            entity.Title = r.Title;
            entity.Description = r.Description;
            entity.Amount = r.Amount;
            entity.IsIncome = r.Type == 1; // 1 ise Gelir, değilse Gider
            entity.Date = r.Date.ToUniversalTime();

            await _repo.UpdateAsync(entity);
            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return new ServiceResponse<bool>("Kayıt bulunamadı", false);

            await _repo.DeleteAsync(entity);
            return new ServiceResponse<bool>(true);
        }
    }
}