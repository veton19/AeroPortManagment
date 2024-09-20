using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface ISecurityRepository
    {
        public List<Security> GetAll();
        public Security GetSecurityId(Guid id);
        public void Create(Security security);
        public void Update(Security security);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
