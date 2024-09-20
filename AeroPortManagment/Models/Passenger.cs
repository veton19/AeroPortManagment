namespace AeroPortManagment.Models
{
    public class Passenger
    {
        public Guid PassengerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PassportNumber { get; set; }
        public string? FlightNumber { get; set; }
        public string? SeatNumber { get; set; }
        public Flight? Flight { get; set; }
        public virtual List<Booking>? Bookings { get; set; }
    }
}
