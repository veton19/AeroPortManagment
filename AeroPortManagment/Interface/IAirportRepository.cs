using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IAirportRepository
    {
        public List<Airport> GetAll();
        public Airport GetAirportById(Guid id);
        public void Create(Airport airport);
        public void Update(Airport airport);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
