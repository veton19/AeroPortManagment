using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IBookingRepository
    {
        public List<Booking> GetAll();
        public Booking GetBookingById(Guid id);
        public void Create(Booking booking);
        public void Update(Booking booking);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
