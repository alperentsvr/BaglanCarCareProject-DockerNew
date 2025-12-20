using BaglanCarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BaglanCarCare.Persistence.Configurations { public class CustomerCfg : IEntityTypeConfiguration<Customer> { public void Configure(EntityTypeBuilder<Customer> b) { b.ToTable("Customers"); b.Property(x => x.PhoneNumber).HasMaxLength(20); } } }