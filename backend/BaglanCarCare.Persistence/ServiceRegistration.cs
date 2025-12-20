using BaglanCarCare.Application.Interfaces.Repositories;
using BaglanCarCare.Persistence.Contexts;
using BaglanCarCare.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BaglanCarCare.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection s, IConfiguration c)
        {
            s.AddDbContext<BaglanCarCareDbContext>(o => o.UseNpgsql(c.GetConnectionString("DefaultConnection")));
            s.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}