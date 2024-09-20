namespace AeroPortManagment.DTOs
{
    public class AirportDTO
    {
        public Guid AirportId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public List<EmployeeDTO>? Employees { get; set; }
        public List<FlightDTO>? Flights { get; set; }
    }
}
