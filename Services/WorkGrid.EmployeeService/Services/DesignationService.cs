
using Microsoft.EntityFrameworkCore;
using WorkGrid.EmployeeService.Data;
using WorkGrid.EmployeeService.DTOs;
using WorkGrid.EmployeeService.Models;

namespace WorkGrid.EmployeeService.Services;

public class DesignationService : IDesignationService
{
    private readonly EmployeeDbContext _context;

    public DesignationService(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<List<DesignationResponseDto>> GetAllAsync()
    {
        return await _context.Designations
            .Select(d => new DesignationResponseDto
            {
                DesignationId = d.DesignationId,
                Name = d.Name,
                Description = d.Description,
                CreatedAt = d.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<DesignationResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Designations
            .Where(d => d.DesignationId == id)
            .Select(d => new DesignationResponseDto
            {
                DesignationId = d.DesignationId,
                Name = d.Name,
                Description = d.Description,
                CreatedAt = d.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    public async Task<DesignationResponseDto> CreateAsync(
        CreateDesignationDto dto)
    {
        var designation = new Designation
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        _context.Designations.Add(designation);
        await _context.SaveChangesAsync();

        return (await GetByIdAsync(designation.DesignationId))!;
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateDesignationDto dto)
    {
        var designation = await _context.Designations
            .FirstOrDefaultAsync(d => d.DesignationId == id);

        if (designation == null)
        {
            return false;
        }

        designation.Name = dto.Name;
        designation.Description = dto.Description;

        await _context.SaveChangesAsync();

        return true;
    }
}
