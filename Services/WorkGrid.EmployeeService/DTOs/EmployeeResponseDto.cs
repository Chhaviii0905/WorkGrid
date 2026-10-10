namespace WorkGrid.EmployeeService.DTOs;

public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;

    public int DesignationId { get; set; }

    public string DesignationName { get; set; } = string.Empty;

    public DateTime DateOfJoining { get; set; }

    public bool IsActive { get; set; }
}