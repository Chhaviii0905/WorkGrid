using Microsoft.EntityFrameworkCore;
using WorkGrid.EmployeeService.Data;
using WorkGrid.EmployeeService.DTOs;
using WorkGrid.EmployeeService.Models;

namespace WorkGrid.EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;
        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeResponseDto>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Designation)
                .Include(e => e.Department)
                .Select(e => new EmployeeResponseDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.Name,
                    DesignationId = e.DesignationId,
                    DesignationName = e.Designation.Name,
                    DateOfJoining = e.DateOfJoining,
                    IsActive = e.IsActive
                })
            .ToListAsync();
        }

        public async Task<EmployeeResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Where(e => e.EmployeeId == id)
                .Select(e => new EmployeeResponseDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.Name,
                    DesignationId = e.DesignationId,
                    DesignationName = e.Designation.Name,
                    DateOfJoining = e.DateOfJoining,
                    IsActive = e.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EmployeeResponseDto> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DepartmentId = dto.DepartmentId,
                DesignationId = dto.DesignationId,
                DateOfJoining = dto.DateOfJoining,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(employee.EmployeeId))!;
        }

        public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return false;
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.DepartmentId = dto.DepartmentId;
            employee.DesignationId = dto.DesignationId;
            employee.DateOfJoining = dto.DateOfJoining;
            employee.IsActive = dto.IsActive;
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return false;
            }

            employee.IsActive = false;
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
