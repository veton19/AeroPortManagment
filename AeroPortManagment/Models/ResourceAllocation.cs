namespace AeroPortManagment.Models
{
    public class ResourceAllocation
    {
        public Guid ResourceId { get; set; }
        public string? Type { get; set; }
        public Guid FlightId { get; set; }
        public DateTime AllocationTime { get; set; }
        public DateTime ReleaseTime { get; set; }
        public virtual Flight? Flight { get; set; }
    }
}
