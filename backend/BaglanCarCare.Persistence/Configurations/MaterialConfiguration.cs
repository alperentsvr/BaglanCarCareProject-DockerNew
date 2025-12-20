using BaglanCarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BaglanCarCare.Persistence.Configurations { public class MaterialCfg : IEntityTypeConfiguration<Material> { public void Configure(EntityTypeBuilder<Material> b) { b.ToTable("Materials"); } } }