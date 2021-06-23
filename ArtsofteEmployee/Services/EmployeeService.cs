using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtsofteEmployee.Abstract;
using ArtsofteEmployee.Contexts;
using ArtsofteEmployee.Models.Person;
using Microsoft.EntityFrameworkCore;

namespace ArtsofteEmployee.Services {
  public class EmployeeService : IEmployeeService {
    private readonly ArtsofteContext _context;

    public EmployeeService(ArtsofteContext context) {
      _context = context;
    }

    public async Task Add(Employee employee) {
      await _context.Employees.AddAsync(employee);
      _context.SaveChanges();
    }

    public async Task Edit(Employee employee) {
      var toEditEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
      if (toEditEmployee is not null) {
        toEditEmployee.Name = employee.Name;
        toEditEmployee.Surname = employee.Surname;
        toEditEmployee.Age = employee.Age;
        toEditEmployee.Gender = employee.Gender;
        toEditEmployee.DepartmentId = employee.DepartmentId;
        toEditEmployee.ProgrammingLanguageId = employee.ProgrammingLanguageId;
        _context.SaveChanges();
      }
    }

    public async Task<IEnumerable<Employee>> Get() {
      return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetById(Guid id) {
      return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Remove(Guid id) {
      var toDeleteEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
      if (toDeleteEmployee is not null) {
        _context.Employees.Remove(toDeleteEmployee);
        _context.SaveChanges();
      }
    }
  }
}
