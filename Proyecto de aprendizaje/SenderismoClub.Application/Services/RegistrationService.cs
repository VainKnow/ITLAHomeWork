using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;
using SenderismoClub.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace SenderismoClub.Application.Services;

public class RegistrationService : IRegistrationService
{
    private readonly AppDbContext _context;

    public RegistrationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task RegisterMemberAsync(int memberId, int excursionId)
    {
        var exists = await _context.Registrations
            .AnyAsync(r => r.MemberId == memberId && r.ExcursionId == excursionId);

        if (exists)
            throw new Exception("Member already registered in this excursion");

        var member = await _context.Members.FindAsync(memberId);
        var excursion = await _context.Excursions
            .Include(e => e.Route)
            .FirstOrDefaultAsync(e => e.Id == excursionId);

        if (member == null || excursion == null)
            throw new Exception("Invalid data");

        
        if (member.Level == Domain.Enums.Level.Beginner &&
            excursion.Route.Difficulty == Domain.Enums.Difficulty.Hard)
        {
            throw new Exception("Beginner cannot join hard routes");
        }

        var registration = new Registration
        {
            MemberId = memberId,
            ExcursionId = excursionId,
            Attended = false
        };

        _context.Registrations.Add(registration);
        await _context.SaveChangesAsync();
    }
}