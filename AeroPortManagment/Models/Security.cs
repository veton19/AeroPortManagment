namespace AeroPortManagment.Models
{
    public class Security
    {
        public Guid SecurityId { get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public string? CheckStatus { get; set; }
        public DateTime CheckTime { get; set; }

        public virtual Flight? Flight { get; set; }
        public virtual Passenger? Passenger { get; set; }
    }
}
