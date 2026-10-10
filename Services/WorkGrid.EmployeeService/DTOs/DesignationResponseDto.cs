namespace WorkGrid.EmployeeService.DTOs;

public class DesignationResponseDto
{
    public int DesignationId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}