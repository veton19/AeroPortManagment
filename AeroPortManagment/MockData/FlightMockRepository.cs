using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class FlightMockRepository : IFlightRepository
    {
        private List<Flight> _flights;

        public FlightMockRepository()
        {
            _flights = new List<Flight>
            {
                new Flight
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "AA123",
                    Origin="London",
                    Destination = "Tokyo",
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now,
                    Status = "On-Time",
                    Gate = Helpers.Gate.Gate1
                },
                new Flight
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "AA124",
                    Origin ="Istanbul",
                    Destination = "Tokyo",
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now,
                    Status = "On-Time",
                    Gate = Helpers.Gate.Gate2
                },
                new Flight
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "AA125",
                    Origin ="Paris",
                    Destination = "Prishtina",
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now,
                    Status = "Delay",
                    Gate = Helpers.Gate.Gate3
                }
            };
        }

        public void Create(Flight flight)
        {
            _flights.Add(flight);
        }

        public List<Flight> GetAll()
        {
            return _flights;
        }

        public void Update(Flight flight)
        {
            var updatedFlight = _flights.FirstOrDefault(f => f.Id == flight.Id);
            if (updatedFlight != null)
            {
                updatedFlight.FlightNumber = flight.FlightNumber;
                updatedFlight.Origin = flight.Origin;
                updatedFlight.Destination = flight.Destination;
                updatedFlight.ArrivalTime = flight.ArrivalTime;
                updatedFlight.DepartureTime = flight.DepartureTime;
                updatedFlight.Status = flight.Status;
                updatedFlight.Gate = flight.Gate;
            }
        }

        public Flight GetFlightById(Guid id)
        {
            var flight = _flights.First(f => f.Id == id);
            return flight;
        }

        public void Delete(Guid id)
        {
            var flight = GetFlightById(id);
            if (flight != null)
            {
                _flights.Remove(flight);
            }
        }
        public bool SaveChanges()
        {
            return true;
        }
    }
}
