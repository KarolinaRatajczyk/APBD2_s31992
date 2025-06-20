namespace Poprawa_kol2.DTOs;

public class EmployeeGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;

    public List<InterestedGetDto> InterestedTrainings { get; set; } = null!;
    
    public List<AttendedGetDto> AttendedTrainings { get; set; } = null!;
}