using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Interfaces;
using Teste.Domain.Models;
using Teste.Infra.Context;
using Teste.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Teste.Application.DI
{
    public  class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<AppDbContext> (options => options.UseSqlServer (connection));

            services.AddScoped(typeof(IRepository<Colaborador>), typeof(ColaboradorRepository));
            services.AddScoped(typeof(IRepositoryPonto), typeof(PontoRepository));
            services.AddScoped(typeof(ColaboradorService));
            services.AddScoped(typeof(PontoService));

        }
    }
}
