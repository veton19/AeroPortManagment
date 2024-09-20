namespace AeroPortManagment.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public Guid AirportId { get; set; }
        public string? ContactDetails { get; set; }
        public virtual Airport? Airport { get; set; }
    }
}
