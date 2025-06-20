namespace Poprawa_kol2.DTOs;

public class AttendedGetDto
{
    public int TrainingId { get; set; }
    public string Topic { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime AttendanceDate { get; set; }
    public int? FeedbackScore { get; set; }
}