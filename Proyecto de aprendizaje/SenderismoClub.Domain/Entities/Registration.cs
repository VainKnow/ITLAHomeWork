namespace SenderismoClub.Domain.Entities;

public class Registration
{
    public int Id { get; set; }

    
    public int MemberId { get; set; }
    public Member? Member { get; set; }


    public int ExcursionId { get; set; }
    public Excursion? Excursion { get; set; }

    public bool Attended { get; set; }

    public string? Observations { get; set; }
}