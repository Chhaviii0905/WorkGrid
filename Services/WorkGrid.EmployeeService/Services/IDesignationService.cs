
using WorkGrid.EmployeeService.DTOs;

namespace WorkGrid.EmployeeService.Services;

public interface IDesignationService
{
    Task<List<DesignationResponseDto>> GetAllAsync();

    Task<DesignationResponseDto?> GetByIdAsync(int id);

    Task<DesignationResponseDto> CreateAsync(CreateDesignationDto dto);

    Task<bool> UpdateAsync(int id, UpdateDesignationDto dto);
}
