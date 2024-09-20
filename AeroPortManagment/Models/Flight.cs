using AeroPortManagment.Helpers;

namespace AeroPortManagment.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string? Status { get; set; }
        public Gate Gate { get; set; }
        public virtual List<Passenger>? Passengers { get; set; }
        public virtual List<Booking>? Bookings { get; set; }
        public virtual List<ResourceAllocation>? ResourceAllocations { get; set; }
    }
}
