using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class ResourceAllocationMockRepository : IResourceAllocationRepository
    {
        private List<ResourceAllocation> _resourceAllocationList;
        public ResourceAllocationMockRepository()
        {
            _resourceAllocationList = new List<ResourceAllocation>
            {
                new ResourceAllocation
                {
                    ResourceId = Guid.NewGuid(),
                    Type = "Gate",
                    FlightId = Guid.NewGuid(),
                    AllocationTime = DateTime.UtcNow.AddHours(-2),
                    ReleaseTime = DateTime.UtcNow.AddHours(1),
                },
                new ResourceAllocation()
                {
                    ResourceId = Guid.NewGuid(),
                    Type = "Crew",
                    FlightId = Guid.NewGuid(),
                    AllocationTime = DateTime.UtcNow.AddHours(-3),
                    ReleaseTime = DateTime.UtcNow.AddMinutes(30),
                },
                new ResourceAllocation()
                {
                    ResourceId = Guid.NewGuid(),
                    Type = "Crew",
                    FlightId = Guid.NewGuid(),
                    AllocationTime = DateTime.UtcNow.AddHours(-3),
                    ReleaseTime = DateTime.UtcNow.AddMinutes(30),
                }
            };
        }
        public void Create(ResourceAllocation resourceAllocation)
        {
            _resourceAllocationList.Add(resourceAllocation);
        }

        public void Delete(Guid id)
        {
            var resource=GetResourceById(id);
            if(resource != null)
            {
                _resourceAllocationList.Remove(resource);
            }
        }

        public List<ResourceAllocation> GetAll()
        {
            return _resourceAllocationList;
        }

        public ResourceAllocation GetResourceById(Guid id)
        {
            var resource=_resourceAllocationList.First(r=>r.ResourceId==id);
            return resource;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(ResourceAllocation resourceAllocation)
        {
            var updatedResource=GetResourceById(resourceAllocation.ResourceId);
            if(updatedResource != null)
            {
                updatedResource.ReleaseTime = resourceAllocation.AllocationTime;
                updatedResource.AllocationTime = resourceAllocation.ReleaseTime;
                updatedResource.Type = resourceAllocation.Type;
            }
        }
    }
}
