namespace AeroPortManagment.HelperDto
{
    public class CreateCommercialActivityDTO
    {
        public string? Type { get; set; }
        public Guid PassengerId { get; set; }
        public Guid FlightId { get; set; }
        public DateTime ActivityTime { get; set; }
        public decimal AmountSpent { get; set; }
    }
}
