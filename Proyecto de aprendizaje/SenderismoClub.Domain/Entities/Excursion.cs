namespace SenderismoClub.Domain.Entities;

public class Excursion
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

   
    public int RouteId { get; set; }
    public Route? Route { get; set; }

    
    public List<Registration> Registrations { get; set; } = new();
}
