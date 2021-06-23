using ArtsofteEmployee.Models.Dictioneries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Contexts.Configurations {
  public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage> {
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder) {
      builder.HasKey(x => x.Id);
      builder.HasMany(x => x.Employees)
        .WithOne(x => x.ProgrammingLanguage);
      builder.Property(x => x.Name)
        .HasMaxLength(30)
        .IsRequired();
    }
  }
}
