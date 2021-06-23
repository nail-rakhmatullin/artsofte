using ArtsofteEmployee.Abstract;
using ArtsofteEmployee.Models.Dictioneries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Controllers {
  public class ProgrammingLanguageController : Controller {
    private readonly IProgrammingLanguageService _programmingLanguageService;

    public ProgrammingLanguageController(IProgrammingLanguageService programmingLanguageService) {
      _programmingLanguageService = programmingLanguageService;
    }

    [HttpGet]
    public async Task<IActionResult> Show() {
      var languages = await _programmingLanguageService.Get();
      return View(languages);
    }

    public IActionResult Add() {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] ProgrammingLanguage language) {
      language.Id = Guid.NewGuid();
      await _programmingLanguageService.Add(language);
      return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(Guid id) {
      var language = await _programmingLanguageService.GetById(id);
      return View(language);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] ProgrammingLanguage language) {
      await _programmingLanguageService.Edit(language);
      return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<string> Get() {
      var languages = await _programmingLanguageService.Get();
      var deps = languages.Select(x => new { x.Id, x.Name }).ToList();
      var json = JsonConvert.SerializeObject(deps);
      return json;
    }

  }
}
