using Microsoft.EntityFrameworkCore;
using WorkGrid.EmployeeService.Data;
using WorkGrid.EmployeeService.DTOs;
using WorkGrid.EmployeeService.Models;

namespace WorkGrid.EmployeeService.Services;

public class DepartmentService : IDepartmentService
{
    private readonly EmployeeDbContext _context;

    public DepartmentService(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<List<DepartmentResponseDto>> GetAllAsync()
    {
        return await _context.Departments
            .Select(d => new DepartmentResponseDto
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Description = d.Description,
                CreatedAt = d.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<DepartmentResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Departments
            .Where(d => d.DepartmentId == id)
            .Select(d => new DepartmentResponseDto
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Description = d.Description,
                CreatedAt = d.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    public async Task<DepartmentResponseDto> CreateAsync(
        CreateDepartmentDto dto)
    {
        var department = new Department
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        return (await GetByIdAsync(department.DepartmentId))!;
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateDepartmentDto dto)
    {
        var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.DepartmentId == id);

        if (department == null)
        {
            return false;
        }

        department.Name = dto.Name;
        department.Description = dto.Description;

        await _context.SaveChangesAsync();

        return true;
    }
}