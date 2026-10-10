namespace WorkGrid.EmployeeService.DTOs
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public DateTime DateOfJoining { get; set; }
    }
}
