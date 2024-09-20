using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        public AeroPortContext _context;
        public AirlineRepository(AeroPortContext context)
        {
            _context = context;     
        }
        
        public void Create(Airline airline)
        {
            _context.Airlines.Add(airline);
        }

        public void Delete(Guid id)
        {
            var airline = _context.Airlines.Find(id);
            if (airline != null)
            {
                _context.Airlines.Remove(airline);
            }
        }

        public List<Airline> GetAll()
        {
            return _context.Airlines.ToList();
        }
        public Airline GetAirlineById(Guid id)
        {
            var airline = _context.Airlines.Find(id);
            if (airline == null)
            {
                throw new Exception("airline not found");
            }
            return airline;
        }

        public void Update(Airline airline)
        {
            _context.Airlines.Update(airline);
        }

        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
