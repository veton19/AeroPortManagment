using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        public AeroPortContext _context;
        public SecurityRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(Security security)
        {
            _context.Securities.Add(security);
        }

        public void Delete(Guid id)
        {
            var security = _context.Securities.Find(id);
            if (security != null)
            {
                _context.Securities.Remove(security);
            }
        }

        public List<Security> GetAll()
        {
            return _context.Securities.ToList();
        }

        public Security GetSecurityId(Guid id)
        {
            var security = _context.Securities.Find(id);
            if (security == null)
            {
                throw new Exception("Security not found");
            }
            return security;
        }

        public void Update(Security security)
        {
            _context.Securities.Update(security);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
