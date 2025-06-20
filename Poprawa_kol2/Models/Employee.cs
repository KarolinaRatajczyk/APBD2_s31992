using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poprawa_kol2.Models;

public class Employee
{
    [Column("ID")]
    [Key]
    public int Id { get; set; }

    [MaxLength(150)]
    public string Name { get; set; } = null!;
    
    [MaxLength(50)]
    public string Department { get; set; } = null!;
    
    public ICollection<TrainingAttendance> Attendances { get; set; } = new List<TrainingAttendance>();
    
    public ICollection<EmployeeTrainingInterest> Interests { get; set; } = new List<EmployeeTrainingInterest>();
    
}