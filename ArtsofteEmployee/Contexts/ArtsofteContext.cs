using ArtsofteEmployee.Contexts.Configurations;
using ArtsofteEmployee.Models.Dictioneries;
using ArtsofteEmployee.Models.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Contexts {
  public class ArtsofteContext : DbContext {

    public ArtsofteContext(DbContextOptions<ArtsofteContext> options) : base(options) {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      if (!options.IsConfigured) {
        options.UseSqlServer(@"Server=.\SQLEXPRESS;Initial Catalog=ArtsofteBase;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
      modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
      modelBuilder.ApplyConfiguration(new ProgrammingLanguageConfiguration());
    }

    #region Person
    public DbSet<Employee> Employees { get; set; }
    #endregion
    
    #region Dictionarties
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    #endregion

  }
}
