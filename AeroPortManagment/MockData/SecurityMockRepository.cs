using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class SecurityMockRepository : ISecurityRepository
    {
        private List<Security> _securities;
        public SecurityMockRepository()
        {
            _securities = new List<Security>
            {
                new Security
                {
                    SecurityId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    PassengerId = Guid.NewGuid(),
                    CheckStatus = "Cleared",
                    CheckTime = DateTime.UtcNow.AddMinutes(-30),
                },
                new Security
                {
                    SecurityId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    PassengerId = Guid.NewGuid(),
                    CheckStatus = "Pending",
                    CheckTime = DateTime.UtcNow.AddMinutes(-10),
                },
                new Security
                {
                    SecurityId= Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    PassengerId = Guid.NewGuid(),
                    CheckStatus = "Cleared",
                    CheckTime = DateTime.UtcNow.AddMinutes(-20),
                }
            };
        }
        public void Create(Security security)
        {
            _securities.Add(security);
        }

        public void Delete(Guid id)
        {
            var securities = GetSecurityId(id);
            if (securities != null)
            {
                _securities.Remove(securities);
            }
        }

        public List<Security> GetAll()
        {
            return _securities;
        }

        public Security GetSecurityId(Guid id)
        {
            var securities=_securities.First(s=>s.SecurityId == id);
            return securities;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(Security security)
        {
            var updatedSecurities= GetSecurityId(security.SecurityId);
            if (updatedSecurities != null)
            {
                updatedSecurities.CheckTime = security.CheckTime;
                updatedSecurities.CheckStatus = security.CheckStatus;
            }
        }
    }
}
