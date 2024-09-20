using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IPassengerRepository
    {
        public List<Passenger> GetAll();
        public Passenger GetById(Guid id);
        public void Create(Passenger passenger);   
        public void Update(Passenger passenger);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
