using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class FlightRepository : IFlightRepository
    { 
        private AeroPortContext _context;
        public FlightRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(Flight flight)
        {
            _context.Flights.Add(flight);
        }


        public List<Flight> GetAll()
        {
            return _context.Flights.ToList();
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public Flight GetFlightById(Guid id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null)
            {
                // Handle the case when no flight is found
                // For example, you can throw an exception or return a default value
                throw new Exception("Flight not found");
            }
            return flight;
        }

        public void Delete(Guid id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }
    }
}
