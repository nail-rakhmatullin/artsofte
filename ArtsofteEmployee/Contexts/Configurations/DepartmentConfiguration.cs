using ArtsofteEmployee.Models.Dictioneries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Contexts.Configurations {
  public class DepartmentConfiguration : IEntityTypeConfiguration<Department> {
    public void Configure(EntityTypeBuilder<Department> builder) {
      builder.HasKey(x => x.Id);
      builder.HasMany(x => x.Employees)
        .WithOne(x => x.Department);
      builder.Property(x => x.Name)
        .HasMaxLength(30)
        .IsRequired();
      builder.Property(x => x.Floor)
        .IsRequired();
    }
  }
}
