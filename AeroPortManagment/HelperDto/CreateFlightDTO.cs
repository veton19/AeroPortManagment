using AeroPortManagment.Helpers;

namespace AeroPortManagment.HelperDto
{
    public class CreateFlightDTO
    {
        public string? FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string? Status { get; set; }
        public Gate Gate { get; set; }
    }
}
