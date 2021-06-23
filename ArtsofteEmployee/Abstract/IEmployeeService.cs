using ArtsofteEmployee.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Abstract {
  public interface IEmployeeService {
    Task<IEnumerable<Employee>> Get();

    Task<Employee> GetById(Guid id);

    Task Edit(Employee employee);

    Task Add(Employee employee);

    Task Remove(Guid id);
  }
}
