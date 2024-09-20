﻿namespace AeroPortManagment.Models
{
    public class Airport
    {
        public Guid AirportId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Flight>? Flights { get; set; }
    }
}
