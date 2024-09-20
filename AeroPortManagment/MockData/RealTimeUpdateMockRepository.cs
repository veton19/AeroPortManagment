using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class RealTimeUpdateMockRepository : IRealTimeUpdateRepository
    {
        private List<RealTimeUpdate> _realTimeUpdate;
        public RealTimeUpdateMockRepository()
        {
            _realTimeUpdate = new List<RealTimeUpdate>
            {
                new RealTimeUpdate()
                {
                    UpdateId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    UpdateType = "Delay",
                    UpdateTime = DateTime.UtcNow.AddMinutes(-15),
                    Details = "Flight delayed due to weather conditions",
                },
                new RealTimeUpdate()
                {
                    UpdateId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    UpdateType = "Gate Change",
                    UpdateTime = DateTime.UtcNow.AddMinutes(-30),
                    Details = "Gate changed from A5 to B3",
                },
                new RealTimeUpdate()
                {
                    UpdateId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    UpdateType = "Delay",
                    UpdateTime = DateTime.UtcNow.AddMinutes(-45),
                    Details = "Flight delayed due to weather conditions",
                }
            };
        }
        public void Create(RealTimeUpdate realTimeUpdate)
        {
            _realTimeUpdate.Add(realTimeUpdate);
        }

        public void Delete(Guid id)
        {
            var realTimeUpdate = GetRealTimeUpdatesId(id);
            if (realTimeUpdate != null)
            {
                _realTimeUpdate.Remove(realTimeUpdate);
            }
        }

        public List<RealTimeUpdate> GetAll()
        {
            return _realTimeUpdate;
        }

        public RealTimeUpdate GetRealTimeUpdatesId(Guid id)
        {
            var realTimeUpdate = _realTimeUpdate.First(r => r.UpdateId == id);
            return realTimeUpdate;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(RealTimeUpdate realTimeUpdate)
        {
            var realTimeUpdated=GetRealTimeUpdatesId(realTimeUpdate.UpdateId);
            if (realTimeUpdated != null)
            {
                realTimeUpdated.UpdateType = realTimeUpdate.UpdateType;
                realTimeUpdated.UpdateTime = realTimeUpdate.UpdateTime;
                realTimeUpdated.Details = realTimeUpdate.Details;
            }
        }
    }
}
