using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoProductosAPI.Models;

namespace ProyectoProductosAPI.Data
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

