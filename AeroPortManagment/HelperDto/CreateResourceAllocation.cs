namespace AeroPortManagment.HelperDto
{
    public class CreateResourceAllocation
    {
        public string? Type { get; set; }
        public Guid FlightId { get; set; }
        public DateTime AllocationTime { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}
