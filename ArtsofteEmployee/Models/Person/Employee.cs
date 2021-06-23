using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ArtsofteEmployee.Models.Dictioneries;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtsofteEmployee.Models.Person {
  public class Employee {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; } 
    [Range(1,90)]
    public int Age { get; set; }
    public string Gender { get; set; }

    public Guid DepartmentId { get; set; }
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department Department { get; set; } 

    public Guid ProgrammingLanguageId { get; set; }
    [ForeignKey(nameof(ProgrammingLanguageId))]
    public virtual ProgrammingLanguage ProgrammingLanguage { get; set; } 
  }
}
