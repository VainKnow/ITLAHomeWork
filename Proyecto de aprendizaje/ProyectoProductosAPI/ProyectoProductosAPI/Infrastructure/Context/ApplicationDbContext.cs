using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoProductosAPI.Domain.Entities;

namespace ProyectoProductosAPI.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}

