namespace AeroPortManagment.DTOs
{
    public class ResourceAllocationDTO
    {
        public Guid ResourceId { get; set; }
        public string? Type { get; set; }
        public Guid FlightId { get; set; }
        public DateTime AllocationTime { get; set; }
        public DateTime ReleaseTime { get; set; }
        public FlightDTO? Flight { get; set; }
    }
}
