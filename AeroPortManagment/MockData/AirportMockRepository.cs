using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class AirportMockRepository : IAirportRepository
    {
        private List<Airport> _airports;
        public AirportMockRepository()
        {
            _airports = new List<Airport>
            {
                new Airport
                {
                    AirportId = Guid.NewGuid(),
                    Name = "Hamad International Airport",
                    City = "Doha",
                    Country = "Qatar",
                    IATA = "AP1",
                    ICAO = "APC1"
                },
                new Airport
                {
                    AirportId = Guid.NewGuid(),
                    Name = "Zurich Airport",
                    City = "Zurich",
                    Country = "Switzerland",
                    IATA = "AP2",
                    ICAO = "APC2"
                },
                new Airport
                {
                    AirportId = Guid.NewGuid(),
                    Name = "Rinas",
                    City = "Tirana",
                    Country = "Albania",
                    IATA = "AP3",
                    ICAO = "APC3"
                }
            };
        }
        public void Create(Airport airport)
        {
            _airports.Add(airport);
        }

        public void Delete(Guid id)
        {
            var airport = GetAirportById(id);
            if (airport != null)
            {
                _airports.Remove(airport);
            }
        }

        public Airport GetAirportById(Guid id)
        {
            var airport=_airports.First(a=>a.AirportId==id);
            return airport;
        }

        public List<Airport> GetAll()
        {
            return _airports;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(Airport airport)
        {
            var updatedAirport = GetAirportById(airport.AirportId);
            if (updatedAirport != null)
            {
                updatedAirport.Name = airport.Name;
                updatedAirport.City = airport.City;
                updatedAirport.Country = airport.Country;
                updatedAirport.IATA = airport.IATA;
                updatedAirport.ICAO = airport.ICAO;
            }
        }
    }
}
