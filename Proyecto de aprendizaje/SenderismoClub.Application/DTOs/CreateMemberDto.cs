namespace SenderismoClub.Application.DTOs;

public class CreateMemberDto
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Level { get; set; }
    public string Phone { get; set; } = string.Empty;
}
