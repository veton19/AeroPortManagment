using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class RealTimeUpdateRepository : IRealTimeUpdateRepository
    {
        public AeroPortContext _context;
        public RealTimeUpdateRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(RealTimeUpdate realTimeUpdate)
        {
            _context.RealTimeUpdates.Add(realTimeUpdate);
        }

        public void Delete(Guid id)
        {
            var updates = _context.RealTimeUpdates.Find(id);
            if(updates != null)
            {
                _context.RealTimeUpdates.Remove(updates);
            }
        }

        public List<RealTimeUpdate> GetAll()
        {
            return _context.RealTimeUpdates.ToList();
        }

        public RealTimeUpdate GetRealTimeUpdatesId(Guid id)
        {
            var updates = _context.RealTimeUpdates.Find(id);
            if (updates == null)
            {
                throw new Exception("Updates not found");
            }
            return updates;
        }

        public void Update(RealTimeUpdate realTimeUpdate)
        {
            _context.RealTimeUpdates.Update(realTimeUpdate);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
