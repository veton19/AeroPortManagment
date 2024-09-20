namespace AeroPortManagment.Models
{
    public class Airline
    {
        public Guid AirlineId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public virtual List<Flight>? Flights { get; set; }
    }
}
