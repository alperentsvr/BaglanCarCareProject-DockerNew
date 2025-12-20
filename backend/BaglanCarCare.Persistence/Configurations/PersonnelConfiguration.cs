using BaglanCarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BaglanCarCare.Persistence.Configurations { public class PersonnelCfg : IEntityTypeConfiguration<Personnel> { public void Configure(EntityTypeBuilder<Personnel> b) { b.ToTable("Personnels"); b.Property(x => x.Salary).HasColumnType("decimal(18,2)"); } } }