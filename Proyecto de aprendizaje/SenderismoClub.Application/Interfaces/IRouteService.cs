using SenderismoClub.Domain.Entities;

namespace SenderismoClub.Application.Interfaces;

public interface IRouteService
{
    Task<List<Route>> GetAllAsync();
    Task<Route> CreateAsync(Route route);
}
