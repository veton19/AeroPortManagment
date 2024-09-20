using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class BookingMockRepository : IBookingRepository
    {
        private List<Booking> _bookings;
        public BookingMockRepository()
        {
            _bookings = new List<Booking>
            {
                new Booking
                {
                    BookingId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    PassengerId = Guid.NewGuid(),
                    BookingDate = DateTime.Now,
                    BookingStatus = "Confirmed",
                    BookingPayment = "Not-Paid"
                },
                new Booking
                {
                    BookingId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    PassengerId = Guid.NewGuid(),
                    BookingDate = DateTime.Now,
                    BookingStatus = "Confirmed",
                    BookingPayment = "Paid"
                },
                new Booking
                {
                    BookingId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    PassengerId = Guid.NewGuid(),
                    BookingDate = DateTime.Now,
                    BookingStatus = "Confirmed",
                    BookingPayment = "Paid"
                }
            };
        }
        public void Create(Booking booking)
        {
            _bookings.Add(booking);
        }

        public void Delete(Guid id)
        {
            var booking=GetBookingById(id);
            if(booking!=null)
            {
                _bookings.Remove(booking);
            }
        }

        public List<Booking> GetAll()
        {
            return _bookings;
        }

        public Booking GetBookingById(Guid id)
        {
            var booking = _bookings.First(b => b.BookingId == id);
            return booking;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(Booking booking)
        {
            var updatedBooking=GetBookingById(booking.BookingId);
            if(updatedBooking!=null)
            {
                updatedBooking.BookingDate = booking.BookingDate;
                updatedBooking.BookingStatus=booking.BookingStatus;
                updatedBooking.BookingPayment=booking.BookingPayment;
            }
        }
    }
}
