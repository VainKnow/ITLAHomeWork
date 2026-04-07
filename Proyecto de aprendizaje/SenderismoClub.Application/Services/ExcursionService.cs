using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;
using SenderismoClub.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace SenderismoClub.Application.Services;

public class ExcursionService : IExcursionService
{
    private readonly AppDbContext _context;

    public ExcursionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Excursion>> GetAllAsync()
    {
        return await _context.Excursions
            .Include(e => e.Route)
            .ToListAsync();
    }

    public async Task<Excursion> CreateAsync(Excursion excursion)
    {
        var routeExists = await _context.Routes.AnyAsync(r => r.Id == excursion.RouteId);

        if (!routeExists)
            throw new Exception("Route does not exist");

        _context.Excursions.Add(excursion);
        await _context.SaveChangesAsync();

        return excursion;
    }
}