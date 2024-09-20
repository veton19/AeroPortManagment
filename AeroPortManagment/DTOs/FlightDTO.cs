namespace AeroPortManagment.DTOs
{
    public class FlightDTO
    {
        public Guid Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string? Status { get; set; }
        public List<PassengerDTO>? Passengers { get; set; }
        public List<BookingDTO>? Bookings { get; set; }
        public List<ResourceAllocationDTO>? ResourceAllocations { get; set; }
    }
}
