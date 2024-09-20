using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface ICommercialActivityRepository
    {
        public List<CommercialActivity> GetAll();
        public CommercialActivity GetCommercialActivityById(Guid id);
        public void Create(CommercialActivity commercialActivity);
        public void Update(CommercialActivity commercialActivity);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
