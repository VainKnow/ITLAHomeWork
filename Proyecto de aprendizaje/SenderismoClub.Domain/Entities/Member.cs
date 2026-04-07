using SenderismoClub.Domain.Enums;

namespace SenderismoClub.Domain.Entities;

public class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public Level Level { get; set; }

    public string Phone { get; set; } = string.Empty;

    
    public List<Registration> Registrations { get; set; } = new();
}
