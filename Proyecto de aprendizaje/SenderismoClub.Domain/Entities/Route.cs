using SenderismoClub.Domain.Enums;

namespace SenderismoClub.Domain.Entities;

public class Route
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public double DistanceKm { get; set; }

    public Difficulty Difficulty { get; set; }

    public string Location { get; set; } = string.Empty;

    public List<Excursion> Excursions { get; set; } = new();
}