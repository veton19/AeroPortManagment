namespace AeroPortManagment.DTOs
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
    }
}
