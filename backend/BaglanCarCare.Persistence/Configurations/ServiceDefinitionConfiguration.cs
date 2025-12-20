using BaglanCarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BaglanCarCare.Persistence.Configurations { public class ServiceDefCfg : IEntityTypeConfiguration<ServiceDefinition> { public void Configure(EntityTypeBuilder<ServiceDefinition> b) { b.ToTable("ServiceDefinitions"); } } }