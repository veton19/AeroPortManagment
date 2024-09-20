using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class CommercialActivityRepository : ICommercialActivityRepository
    {
        public AeroPortContext _context;
        public CommercialActivityRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(CommercialActivity commercialActivity)
        {
            _context.CommercialActivities.Add(commercialActivity);
        }

        public void Delete(Guid id)
        {
            var activity = _context.CommercialActivities.Find(id);
            if(activity != null)
            {
                _context.CommercialActivities.Remove(activity);
            }
        }

        public List<CommercialActivity> GetAll()
        {
            return _context.CommercialActivities.ToList();
        }

        public CommercialActivity GetCommercialActivityById(Guid id)
        {
            var activity = _context.CommercialActivities.Find(id);
            if (activity == null)
            {
                throw new Exception("Activity not found");
            }
            return activity;
        }

        public void Update(CommercialActivity commercialActivity)
        {
            _context.CommercialActivities.Update(commercialActivity);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
