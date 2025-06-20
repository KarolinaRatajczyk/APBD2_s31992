using Microsoft.EntityFrameworkCore;
using Poprawa_kol2.DTOs;
using Poprawa_kol2.Data;
using Poprawa_kol2.Exceptions;

namespace Poprawa_kol2.Services;

public interface IDbService
{
    public Task<EmployeeGetDto> GetEmployeeDetailsByIdAsync(int employeeId);
    public Task DeleteEmployeeAsync(int employeeId);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<EmployeeGetDto> GetEmployeeDetailsByIdAsync(int employeeId)
    {
        var result = await data.Employees
            .Where(e => e.Id == employeeId)
            .Select(e => new EmployeeGetDto
            {
                Id = e.Id,
                Name = e.Name,
                Department = e.Department,
                InterestedTrainings = e.Interests.Select(t => new InterestedGetDto
                {
                   TrainingId = t.TrainingId,
                   Topic = t.Training.Topic,
                   Location = t.Training.Location,
                }).ToList(),
                AttendedTrainings = e.Attendances.Select(a => new AttendedGetDto
                {
                    TrainingId = a.TrainingId,
                    Topic = a.Training.Topic,
                    Location = a.Training.Location,
                    AttendanceDate = a.AttendanceDate,
                    FeedbackScore = a.FeedbackScore,
                }).ToList(),
            })
            .FirstOrDefaultAsync();
        
        if (result == null)
            throw new NotFoundException($"Employee with ID {employeeId} not found");

        return result;
    }
    
    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var employee = await data.Employees
            .Include(e => e.Attendances)
            .Include(e => e.Interests)
            .FirstOrDefaultAsync(e => e.Id == employeeId);

        if (employee == null)
            throw new NotFoundException($"Employee with ID: {employeeId} not found");

        data.TrainingAttendances.RemoveRange(employee.Attendances);
        data.Interests.RemoveRange(employee.Interests);
        data.Employees.Remove(employee);

        await data.SaveChangesAsync();
    }
}