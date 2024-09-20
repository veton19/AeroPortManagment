using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class AirlineMockRepository : IAirlineRepository
    {
        private List<Airline> _airlines;
        public AirlineMockRepository()
        {
            _airlines = new List<Airline>
            {
                new Airline
                {
                    AirlineId = Guid.NewGuid(),
                    Name = "Qatar Airway",
                    Country = "Qatar",
                    IATA = "A1",
                    ICAO = "ICA1",
                },
                new Airline
                {
                    AirlineId = Guid.NewGuid(),
                    Name = "Swiss Air",
                    Country = "Switzerland",
                    IATA = "A2",
                    ICAO = "ICA2",
                },
                new Airline
                {
                    AirlineId = Guid.NewGuid(),
                    Name = "Air Albania",
                    Country = "Albania",
                    IATA = "A3",
                    ICAO = "ICA3",
                }
            };
        }
        public List<Airline> GetAll()
        {
            return _airlines;
        }

        public Airline GetAirlineById(Guid id)
        {
            var airlines= _airlines.First(x => x.AirlineId == id);
            return airlines;
        }

        public void Create(Airline airline)
        {
            _airlines.Add(airline);
        }

        public void Update(Airline airline)
        {
            var updatedAirline = _airlines.FirstOrDefault(a =>a.AirlineId  == airline.AirlineId);
            if (updatedAirline != null)
            {
                updatedAirline.Name = airline.Name;
                updatedAirline.Country = airline.Country;
                updatedAirline.IATA = airline.IATA;
                updatedAirline.ICAO = airline.ICAO;
            }
        }

        public void Delete(Guid id)
        {
            var airline=GetAirlineById(id);
            if(airline != null)
            {
                _airlines.Remove(airline);
            }
        }

        public bool SaveChanges()
        {
            return true;
        } 
    }
}
