using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class CommercialActivityMockRepository : ICommercialActivityRepository
    {
        private List<CommercialActivity> _activities;
        public CommercialActivityMockRepository()
        {
            _activities = new List<CommercialActivity>
            {
                new CommercialActivity
                {
                    ActivityId = Guid.NewGuid(),
                    Type = "Duty-Free Shopping",
                    PassengerId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    ActivityTime = DateTime.UtcNow.AddDays(-1),
                    AmountSpent = 150.00m,
                },

                new CommercialActivity
                {
                    ActivityId = Guid.NewGuid(),
                    Type = "Duty-Free Shopping",
                    PassengerId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    ActivityTime = DateTime.UtcNow.AddDays(-1),
                    AmountSpent = 75.00m,
                },

                new CommercialActivity
                {
                    ActivityId = Guid.NewGuid(),
                    Type = "Duty-Free Shopping",
                    PassengerId = Guid.NewGuid(),
                    FlightId = Guid.NewGuid(),
                    ActivityTime = DateTime.UtcNow.AddDays(-1),
                    AmountSpent = 100.00m,
                }
            };
        }
        public void Create(CommercialActivity commercialActivity)
        {
            _activities.Add(commercialActivity);
        }

        public void Delete(Guid id)
        {
            var activities=GetCommercialActivityById(id);
            if(activities!=null)
            {
                _activities.Remove(activities);
            }
        }

        public List<CommercialActivity> GetAll()
        {
            return _activities;
        }

        public CommercialActivity GetCommercialActivityById(Guid id)
        {
            var activities=_activities.First(a=>a.ActivityId==id);
            return activities;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(CommercialActivity commercialActivity)
        {
            var updatedActivities=GetCommercialActivityById(commercialActivity.ActivityId);
            if(updatedActivities!=null)
            {
                updatedActivities.Type=commercialActivity.Type;
                updatedActivities.ActivityTime=commercialActivity.ActivityTime;
                updatedActivities.AmountSpent=commercialActivity.AmountSpent;
            }
        }
    }
}
