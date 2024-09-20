namespace AeroPortManagment.DTOs
{
    public class RealTimeUpdateDTO
    {
        public Guid UpdateId { get; set; }
        public Guid FlightId { get; set; }
        public string? UpdateType { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? Details { get; set; }
        public FlightDTO? Flight { get; set; }
    }
}
