using WorkGrid.EmployeeService.DTOs;

namespace WorkGrid.EmployeeService.Services;

public interface IDepartmentService
{
    Task<List<DepartmentResponseDto>> GetAllAsync();

    Task<DepartmentResponseDto?> GetByIdAsync(int id);

    Task<DepartmentResponseDto> CreateAsync(CreateDepartmentDto dto);

    Task<bool> UpdateAsync(int id, UpdateDepartmentDto dto);
}