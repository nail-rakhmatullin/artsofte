using ArtsofteEmployee.Models.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Models.Dictioneries {
  public class ProgrammingLanguage {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public ProgrammingLanguage() {
      Employees = new List<Employee>();
    }
  }
}
