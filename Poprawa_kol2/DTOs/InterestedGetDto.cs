namespace Poprawa_kol2.DTOs;

public class InterestedGetDto
{
    public int TrainingId { get; set; }
    public string Topic { get; set; } = null!;
    public string Location { get; set; } = null!;
}