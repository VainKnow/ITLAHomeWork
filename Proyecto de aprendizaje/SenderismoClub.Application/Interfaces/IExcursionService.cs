using SenderismoClub.Domain.Entities;

namespace SenderismoClub.Application.Interfaces;

public interface IExcursionService
{
    Task<Excursion> CreateAsync(Excursion excursion);
    Task<List<Excursion>> GetAllAsync();
}