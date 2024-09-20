using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IResourceAllocationRepository
    {
        public List<ResourceAllocation> GetAll();
        public ResourceAllocation GetResourceById(Guid id);
        public void Create(ResourceAllocation resourceAllocation);
        public void Update(ResourceAllocation resourceAllocation);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
