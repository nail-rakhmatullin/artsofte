using ArtsofteEmployee.Abstract;
using ArtsofteEmployee.Models.Dictioneries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArtsofteEmployee.Controllers {
  public class DepartmentController : Controller {
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService) {
      _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Show() {
      var departments = await _departmentService.Get();
      return View(departments);
    }

    public IActionResult Add() {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Department department) {
      department.Id = Guid.NewGuid();
      await _departmentService.Add(department);
      return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(Guid id) {
      var department = await _departmentService.GetById(id);
      return View(department);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] Department department) {
      await _departmentService.Edit(department);
      return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<string> Get() {
      var departments = await _departmentService.Get();
      var deps = departments.Select(x => new { x.Id, x.Name }).ToList();
      var json = JsonConvert.SerializeObject(deps);
      return json;
    }

  }
}
