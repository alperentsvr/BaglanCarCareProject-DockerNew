using BaglanCarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BaglanCarCare.Persistence.Configurations { public class UserCfg : IEntityTypeConfiguration<User> { public void Configure(EntityTypeBuilder<User> b) { b.ToTable("Users"); b.Property(x => x.Username).IsRequired().HasMaxLength(50); } } }