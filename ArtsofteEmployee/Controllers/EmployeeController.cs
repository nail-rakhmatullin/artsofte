using ArtsofteEmployee.Abstract;
using ArtsofteEmployee.Models.Person;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Controllers {
  public class EmployeeController : Controller {
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) {
      _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Show() {
      var employees = await _employeeService.Get();
      return View(employees);
    }

    public IActionResult Add() {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Employee employee) {
      employee.Id = Guid.NewGuid();
      await _employeeService.Add(employee);
      return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(Guid id) {
      var employee = await _employeeService.GetById(id);
      return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] Employee employee) {
      await _employeeService.Edit(employee);
      return RedirectToAction("Index", "Home");
    }

    
    public async Task<IActionResult> Delete(Guid id) {
      await _employeeService.Remove(id);
      return RedirectToAction("Index", "Home");
    }

  }
}
