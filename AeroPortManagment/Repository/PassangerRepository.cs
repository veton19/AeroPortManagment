using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class PassangerRepository : IPassengerRepository
    {
        AeroPortContext _context;
        public PassangerRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
        }

        public List<Passenger> GetAll()
        {
            return _context.Passengers.ToList();
        }

       
        public void Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
        }

        public Passenger GetById(Guid id)
        {
            var passenger = _context.Passengers.Find(id);
            if (passenger == null)
            {
                // Handle the case when no passenger is found
                // You can throw an exception, return a default value, or perform any other appropriate action
                throw new Exception($"Passenger with ID {id} not found.");
            }
            return passenger;
        }

        public void Delete(Guid id)
        {
            var passengers = _context.Passengers.Find(id);
            if (passengers != null)
            {
                _context.Passengers.Remove(passengers);
            }
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }
    }
}
