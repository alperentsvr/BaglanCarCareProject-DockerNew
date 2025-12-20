using BaglanCarCare.Domain.Entities;
using BaglanCarCare.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BaglanCarCare.Persistence.Seeds
{
    public static class ContextSeed
    {
        public static async Task SeedAsync(BaglanCarCareDbContext context)
        {
            var materials = new List<Material> {
                new Material { Name = "Olex Pro-Bond Series", Category = "PPF", QualityGrade = "Premium Plus", WarrantyYears = 7, Thickness = "190 Mikron", Description = "Ultra parlak." },
                new Material { Name = "Olex Nano Ceramic IR", Category = "Cam Filmi", QualityGrade = "Isı Kontrollü", WarrantyYears = 10, Thickness = "2 Mil", Description = "%96 Isı engelleme." }
            };
            foreach (var m in materials) if (!await context.Materials.AnyAsync(x => x.Name == m.Name)) await context.Materials.AddAsync(m);

            var services = new List<ServiceDefinition> {
                new ServiceDefinition { Name = "Full Body PPF", Category = "PPF", IncludedParts = "Tüm Yüzeyler" },
                new ServiceDefinition { Name = "Standart Dış Yıkama", Category = "Yıkama", IncludedParts = "Dış Yıkama, Jant" },
                new ServiceDefinition { Name = "Detaylı İç Kuaför", Category = "Yıkama", IncludedParts = "Koltuk, Taban, Tavan" }
            };
            foreach (var s in services) if (!await context.ServiceDefinitions.AnyAsync(x => x.Name == s.Name)) await context.ServiceDefinitions.AddAsync(s);
            await context.SaveChangesAsync();
        }
    }
}