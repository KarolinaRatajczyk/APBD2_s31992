using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poprawa_kol2.Models;

public class Training
{
    [Column("ID")]
    [Key]
    public int Id { get; set; }
    
    [MaxLength(150)]
    public string Topic { get; set; } = null!;
    
    [MaxLength(150)]
    public string Location { get; set; } = null!;
    
    public ICollection<TrainingAttendance> Attendances { get; set; } = new List<TrainingAttendance>();
    
    public ICollection<EmployeeTrainingInterest> Interests { get; set; } = new List<EmployeeTrainingInterest>();
}