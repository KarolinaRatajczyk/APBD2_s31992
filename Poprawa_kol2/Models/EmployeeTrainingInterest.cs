using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Poprawa_kol2.Models;

[PrimaryKey(nameof(EmployeeId), nameof(TrainingId))]
public class EmployeeTrainingInterest
{
    [Column("Employee_ID")]
    public int EmployeeId { get; set; }
    
    [ForeignKey(nameof(EmployeeId))]
    public virtual Employee Employee { get; set; } = null!;
    
    [Column("Training_ID")]
    public int TrainingId { get; set; }
    
    [ForeignKey(nameof(TrainingId))]
    public virtual Training Training { get; set; } = null!;
}