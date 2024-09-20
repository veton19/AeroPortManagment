namespace AeroPortManagment.DTOs
{
    public class AirlineDTO
    {
        public Guid AirlineId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public List<FlightDTO>? Flights { get; set; }
    }
}
