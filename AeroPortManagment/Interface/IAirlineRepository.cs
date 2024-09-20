using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IAirlineRepository
    {
        public List<Airline> GetAll();
        public Airline GetAirlineById(Guid id);
        public void Create(Airline airline);
        public void Update(Airline airline);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
