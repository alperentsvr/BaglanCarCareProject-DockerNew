using BaglanCarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BaglanCarCare.Persistence.Configurations { public class VehicleCfg : IEntityTypeConfiguration<Vehicle> { public void Configure(EntityTypeBuilder<Vehicle> b) { b.ToTable("Vehicles"); b.Property(x => x.PlateNumber).HasMaxLength(20); b.HasOne(x => x.Customer).WithMany(x => x.Vehicles).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade); } } }