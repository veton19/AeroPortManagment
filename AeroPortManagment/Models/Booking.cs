using System.Collections.Generic;

namespace AeroPortManagment.Models
{
    public class Booking
    {
        public Guid BookingId {  get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string? BookingStatus {  get; set; }
        public string? BookingPayment { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public virtual Flight? Flight { get; set; }
    }
}
