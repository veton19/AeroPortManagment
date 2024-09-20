using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public AeroPortContext _context;
        public BookingRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(Booking booking)
        {
            _context.Bookings.Add(booking);
        }

        public void Delete(Guid id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
        }

        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(Guid id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }
            return booking;
        }

        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
