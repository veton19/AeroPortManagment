using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class PassengerMockRepository : IPassengerRepository
    {
        private List<Passenger> _passenger;
        public PassengerMockRepository()
        {
            _passenger = new List<Passenger>
            {
                new Passenger
                {
                    PassengerId= Guid.NewGuid(),
                    FirstName="Veton",
                    LastName="Sulejmani",
                    PassportNumber="257Cd",
                    FlightNumber="AA123",
                    SeatNumber="28"
                },
                new Passenger
                {
                    PassengerId= Guid.NewGuid(),
                    FirstName="Altin",
                    LastName="Axhami",
                    PassportNumber="256CD",
                    FlightNumber="AA124",
                    SeatNumber="27"
                },
                new Passenger
                {
                    PassengerId= Guid.NewGuid(),
                    FirstName="Visar",
                    LastName="Marku",
                    PassportNumber="255CD",
                    FlightNumber="AA125",
                    SeatNumber="26"
                }

            };
        }

        public void Create(Passenger passenger)
        {
            _passenger.Add(passenger);
        }

        public List<Passenger> GetAll()
        {
            return _passenger;
        }

        public void Update(Passenger passenger)
        {
            var updatedPassenger = _passenger.First(p => p.PassengerId == passenger.PassengerId);
            if (updatedPassenger != null)
            {
                updatedPassenger.PassengerId = passenger.PassengerId;
                updatedPassenger.FirstName = passenger.FirstName;
                updatedPassenger.LastName = passenger.LastName;
                updatedPassenger.PassportNumber = passenger.PassportNumber;
                updatedPassenger.FlightNumber = passenger.FlightNumber;
                updatedPassenger.SeatNumber = passenger.SeatNumber;
            }
        }

        public Passenger GetById(Guid id)
        {
            var passanger = _passenger.First(p => p.PassengerId == id);
            return passanger;
        }

        public void Delete(Guid id)
        {
            var passenger = GetById(id);
            if (passenger != null)
            {
                _passenger.Remove(passenger);
            }
        }
        public bool SaveChanges()
        {
            return true;
        }
    }
}
