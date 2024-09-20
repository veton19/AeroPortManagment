namespace AeroPortManagment.DTOs
{
    public class CommercialActivityDTO
    {
        public Guid ActivityId { get; set; }
        public string? Type { get; set; }
        public Guid PassengerId { get; set; }
        public Guid FlightId { get; set; }
        public DateTime ActivityTime { get; set; }
        public decimal AmountSpent { get; set; }
        public PassengerDTO? Passenger { get; set; }
        public FlightDTO? Flight { get; set; }
    }
}
