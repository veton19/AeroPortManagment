using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IRealTimeUpdateRepository
    {
        public List<RealTimeUpdate> GetAll();
        public RealTimeUpdate GetRealTimeUpdatesId(Guid id);
        public void Create(RealTimeUpdate realTimeUpdate);
        public void Update(RealTimeUpdate realTimeUpdate);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
