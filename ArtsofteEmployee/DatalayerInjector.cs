using ArtsofteEmployee.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteEmployee {
  public static class DatalayerInjector {
    public static IServiceCollection InjectDatalayer(this IServiceCollection services,
        IConfiguration configuration) {
      services.AddDbContext<ArtsofteContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
      return services;
    }
  }
}
