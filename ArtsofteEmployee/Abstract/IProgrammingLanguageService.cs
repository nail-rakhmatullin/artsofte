using ArtsofteEmployee.Models.Dictioneries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee.Abstract {
  public interface IProgrammingLanguageService {
    Task<IEnumerable<ProgrammingLanguage>> Get();

    Task<ProgrammingLanguage> GetById(Guid id);

    Task Edit(ProgrammingLanguage programmingLanguage);

    Task Add(ProgrammingLanguage programmingLanguage);
  }
}
