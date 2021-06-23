using ArtsofteEmployee.Models.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Contexts.Configurations {
  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
    public void Configure(EntityTypeBuilder<Employee> builder) {
      builder.HasKey(x => x.Id);
      builder.HasOne(x => x.ProgrammingLanguage)
        .WithMany(x => x.Employees)
        .OnDelete(DeleteBehavior.NoAction);
      builder.HasOne(x => x.Department)
        .WithMany(x => x.Employees)
        .OnDelete(DeleteBehavior.NoAction);
      builder.Property(x => x.Name)
        .HasMaxLength(30)
        .IsRequired();
      builder.Property(x => x.Surname)
        .HasMaxLength(30)
        .IsRequired();
      builder.Property(x => x.Gender)
        .HasMaxLength(17)
        .IsRequired();
      builder.Property(x => x.Age)
        .IsRequired();
    }
  }
}
