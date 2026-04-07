using SenderismoClub.Domain.Entities;

namespace SenderismoClub.Application.Interfaces;

public interface IMemberService
{
    Task<List<Member>> GetAllAsync();
    Task<Member> CreateAsync(Member member);
}