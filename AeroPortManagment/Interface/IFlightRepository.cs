using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IFlightRepository
    {
        public List<Flight> GetAll();
        public Flight GetFlightById(Guid id);
        public void Create(Flight flight);
        public void Update(Flight flight);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
