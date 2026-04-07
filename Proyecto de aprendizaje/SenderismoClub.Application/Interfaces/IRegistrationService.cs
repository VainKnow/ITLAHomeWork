using SenderismoClub.Domain.Entities;

namespace SenderismoClub.Application.Interfaces;

public interface IRegistrationService
{
    Task RegisterMemberAsync(int memberId, int excursionId);
}