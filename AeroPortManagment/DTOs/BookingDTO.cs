namespace AeroPortManagment.DTOs
{
    public class BookingDTO
    {
        public Guid BookingId { get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string? BookingStatus { get; set; }
        public string? BookingPayment { get; set; }
        public PassengerDTO? Passenger { get; set; }
        public FlightDTO? Flight { get; set; }
    }
}
