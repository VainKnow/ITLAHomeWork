using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;
using SenderismoClub.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace SenderismoClub.Application.Services;

public class MemberService : IMemberService
{
    private readonly AppDbContext _context;

    public MemberService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetAllAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<Member> CreateAsync(Member member)
    {
        if (member.Age < 10)
            throw new Exception("Member must be at least 10 years old");

        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return member;
    }
}
