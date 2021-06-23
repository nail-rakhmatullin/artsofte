using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtsofteEmployee.Abstract;
using ArtsofteEmployee.Contexts;
using ArtsofteEmployee.Models.Dictioneries;
using Microsoft.EntityFrameworkCore;

namespace ArtsofteEmployee.Services {
  public class DepartmentService : IDepartmentService {
    private readonly ArtsofteContext _context;

    public DepartmentService(ArtsofteContext context) {
      _context = context;
    }

    public async Task Add(Department department) {
      await _context.Departments.AddAsync(department);
      _context.SaveChanges();
    }

    public async Task Edit(Department department) {
      var toEditDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);
      if (toEditDepartment is not null) {
        toEditDepartment.Name = department.Name;
        toEditDepartment.Floor = department.Floor;
        _context.SaveChanges();
      }
    }

    public async Task<IEnumerable<Department>> Get() {
      return await _context.Departments.ToListAsync();
    }

    public async Task<Department> GetById(Guid id) {
      return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
