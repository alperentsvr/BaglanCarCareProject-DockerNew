using BaglanCarCare.Application.Interfaces.Services;
using BaglanCarCare.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using BaglanCarCare.Application.Mappings;
namespace BaglanCarCare.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection s)
        {
            s.AddAutoMapper(configuration => { configuration.AddProfile<GeneralMapping>(); });
            s.AddScoped<IAuthService, AuthManager>();// İçine ekleyin:
            s.AddScoped<IOrderService, OrderManager>(); 
            s.AddScoped<IOrderService, OrderManager>(); 
            s.AddScoped<IDashboardService, DashboardManager>();
            s.AddScoped<IPersonnelService, PersonnelManager>(); 
            s.AddScoped<ICustomerService, CustomerManager>();
            s.AddScoped<IVehicleService, VehicleManager>(); 
            s.AddScoped<IMaterialService, MaterialManager>();
            s.AddScoped<IServiceDefService, ServiceDefManager>(); 
            s.AddScoped<IAccountingService, AccountingManager>();
            s.AddScoped<IExpenseService, ExpenseManager>();
            s.AddScoped<IAccountingService, AccountingManager>();
            s.AddScoped<ICatalogService, CatalogManager>();
        }
    }
}
