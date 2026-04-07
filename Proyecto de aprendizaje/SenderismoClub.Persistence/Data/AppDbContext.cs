using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SenderismoClub.Domain.Entities;

namespace SenderismoClub.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Route> Routes => Set<Route>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Excursion> Excursions => Set<Excursion>();
    public DbSet<Registration> Registrations => Set<Registration>();
}