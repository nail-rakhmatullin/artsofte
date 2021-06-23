using ArtsofteEmployee.Models.Dictioneries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Abstract {
  public interface IDepartmentService {
    Task<IEnumerable<Department>> Get();

    Task<Department> GetById(Guid id);

    Task Edit(Department department);

    Task Add(Department department);
  }
}
