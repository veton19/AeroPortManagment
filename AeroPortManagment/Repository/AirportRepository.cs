using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class AirportRepository : IAirportRepository
    {
        public AeroPortContext _context;
        public AirportRepository(AeroPortContext context)
        {
            _context = context;
        }
        
        public void Create(Airport airport)
        {
            _context.Airports.Add(airport);
        }

        public void Delete(Guid id)
        {
            var airport = _context.Airports.Find(id);
            if(airport != null)
            {
                _context.Airports.Remove(airport);
            }
        }

        public List<Airport> GetAll()
        {
            return _context.Airports.ToList();
        }
        public Airport GetAirportById(Guid id)
        {
            var airport = _context.Airports.Find(id);
            if (airport == null)
            {
                throw new Exception("Airport not Found");
            }
            return airport;
        }

        public void Update(Airport airport)
        {
            _context.Airports.Update(airport);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
