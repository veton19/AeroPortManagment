using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class ResourceAllocationRepository : IResourceAllocationRepository
    {
        public AeroPortContext _context;
        public ResourceAllocationRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(ResourceAllocation resourceAllocation)
        {
            _context.ResourceAllocations.Add(resourceAllocation);
        }

        public void Delete(Guid id)
        {
            var resources = _context.ResourceAllocations.Find(id);
            if(resources != null)
            {
                _context.ResourceAllocations.Remove(resources);
            }
        }

        public List<ResourceAllocation> GetAll()
        {
            return _context.ResourceAllocations.ToList();
        }

        public ResourceAllocation GetResourceById(Guid id)
        {
            var resource = _context.ResourceAllocations.Find(id);
            if (resource == null)
            {
                throw new Exception("Resources not found");
            }
            return resource;
        }

        public void Update(ResourceAllocation resourceAllocation)
        {
            _context.ResourceAllocations.Update(resourceAllocation);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
