using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Teste.Domain.Models;

namespace Teste.Infra.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Ponto> Pontos { get; set; }

    }
}
