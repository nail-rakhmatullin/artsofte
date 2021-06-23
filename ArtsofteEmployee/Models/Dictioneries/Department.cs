using ArtsofteEmployee.Models.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Models.Dictioneries {
  public class Department {
    public Guid Id { get; set; }
    public string Name { get; set; }
    [Range(1,96)]
    public int Floor { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public Department() {
      Employees = new List<Employee>();
    }
  }
}
