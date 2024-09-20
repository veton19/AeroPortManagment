namespace AeroPortManagment.HelperDto
{
    public class CreateBookingDTO
    {
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string? BookingStatus { get; set; }
        public string? BookingPayment { get; set; }
    }
}
