namespace AeroPortManagment.DTOs
{
    public class PassengerDTO
    {
        public Guid PassengerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PassportNumber { get; set; }
        public string? FlightNumber { get; set; }
        public string? SeatNumber { get; set; }
        public FlightDTO? Flight { get; set; }
        public List<BookingDTO>? Bookings { get; set; }
    }
}
