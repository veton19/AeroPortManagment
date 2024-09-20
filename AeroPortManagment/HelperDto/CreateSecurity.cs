using AeroPortManagment.DTOs;

namespace AeroPortManagment.HelperDto
{
    public class CreateSecurity
    {
        public string? CheckStatus { get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public DateTime CheckTime { get; set; }
    }
}
