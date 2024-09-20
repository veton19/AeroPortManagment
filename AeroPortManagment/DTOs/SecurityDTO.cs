namespace AeroPortManagment.DTOs
{
    public class SecurityDTO
    {
        public Guid SecurityId { get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public string? CheckStatus { get; set; }
        public DateTime CheckTime { get; set; }
        public FlightDTO? Flight { get; set; }
        public PassengerDTO? Passenger { get; set; }
    }
}
