using System;
using Microsoft.EntityFrameworkCore;
using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;
using SenderismoClub.Persistence.Data;

namespace SenderismoClub.Application.Services;

public class RouteService : IRouteService
{
    private readonly AppDbContext _context;

    public RouteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Route>> GetAllAsync()
    {
        return await _context.Routes.ToListAsync();
    }

    public async Task<Route> CreateAsync(Route route)
    {
        if (string.IsNullOrWhiteSpace(route.Name))
            throw new Exception("Route name is required");

        _context.Routes.Add(route);
        await _context.SaveChangesAsync();

        return route;
    }
}