using Microsoft.EntityFrameworkCore;
using Poprawa_kol2.Models;

namespace Poprawa_kol2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<EmployeeTrainingInterest> Interests { get; set; }
    public DbSet<TrainingAttendance> TrainingAttendances { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "John",
                Department = "IT"
            },
            new Employee
            {
                Id = 2,
                Name = "Jane",
                Department = "Finance"
            }
        );
        
        modelBuilder.Entity<Training>().HasData(
            new Training
            {
                Id = 1,
                Topic = "Podstawy programowania",
                Location = "Washington",
            },
            new Training
            {
                Id = 2,
                Topic = "Bezpieczenstwo",
                Location = "Warsaw",
            }
        );
        
        modelBuilder.Entity<EmployeeTrainingInterest>().HasData(
            new EmployeeTrainingInterest
            {
                EmployeeId = 1,
                TrainingId = 2,
            },
            new EmployeeTrainingInterest
            {
                EmployeeId = 2,
                TrainingId = 1,
            }
        );
        
        modelBuilder.Entity<TrainingAttendance>().HasData(
            new TrainingAttendance
            {
                EmployeeId = 1,
                TrainingId = 1,
                AttendanceDate = new DateTime(2020, 1, 1),
                FeedbackScore = 9
            },
            new TrainingAttendance
            {
                EmployeeId = 2,
                TrainingId = 2,
                AttendanceDate = new DateTime(2020, 1, 1),
                FeedbackScore = null
            }
        );
    }
}