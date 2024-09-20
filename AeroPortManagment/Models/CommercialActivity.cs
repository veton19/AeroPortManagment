namespace AeroPortManagment.Models
{
    public class CommercialActivity
    {
        public Guid ActivityId { get; set; }
        public string? Type { get; set; }
        public Guid PassengerId { get; set; }
        public Guid FlightId { get; set; }
        public DateTime ActivityTime { get; set; }
        public decimal AmountSpent { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public virtual Flight? Flight { get; set; }

    }
}
