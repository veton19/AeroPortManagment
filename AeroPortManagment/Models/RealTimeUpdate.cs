namespace AeroPortManagment.Models
{
    public class RealTimeUpdate
    {
        public Guid UpdateId { get; set; }
        public Guid FlightId { get; set; }
        public string? UpdateType { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? Details { get; set; }
        public virtual Flight? Flight { get; set; }
    }
}
