namespace WorkGrid.EmployeeService.Models;

public class Designation
{
    public int DesignationId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}