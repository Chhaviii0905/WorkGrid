namespace WorkGrid.EmployeeService.Models;

public class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public int DepartmentId { get; set; }

    public int DesignationId { get; set; }

    public DateTime DateOfJoining { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Department Department { get; set; } = null!;

    public Designation Designation { get; set; } = null!;
}