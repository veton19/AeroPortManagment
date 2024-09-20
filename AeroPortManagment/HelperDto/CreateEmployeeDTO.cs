namespace AeroPortManagment.HelperDto
{
    public class CreateEmployeeDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public Guid AirportId { get; set; }
        public string? ContactDetails { get; set; }
    }
}
