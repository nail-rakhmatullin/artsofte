using ArtsofteEmployee.Abstract;
using ArtsofteEmployee.Contexts;
using ArtsofteEmployee.Models.Dictioneries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArtsofteEmployee.Services {
  public class ProgrammingLanguageService : IProgrammingLanguageService {
    private readonly ArtsofteContext _context;

    public ProgrammingLanguageService(ArtsofteContext context) {
      _context = context;
    }

    public async Task Add(ProgrammingLanguage programmingLanguage) {
      await _context.ProgrammingLanguages.AddAsync(programmingLanguage);
      _context.SaveChanges();
    }

    public async Task Edit(ProgrammingLanguage programmingLanguage) {
      var toEditPL = await _context.ProgrammingLanguages.FirstOrDefaultAsync(x => x.Id == programmingLanguage.Id);
      if(toEditPL is not null) {
        toEditPL.Name = programmingLanguage.Name;
        _context.SaveChanges();
      }
    }

    public async Task<IEnumerable<ProgrammingLanguage>> Get() {
      return await _context.ProgrammingLanguages.ToListAsync();
    }

    public async Task<ProgrammingLanguage> GetById(Guid id) {
      return await _context.ProgrammingLanguages.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
