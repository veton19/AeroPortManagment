using AeroPortManagment.Models;

namespace AeroPortManagment.Interface
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();
        public Employee GetEmployeeById(Guid id);
        public void Create(Employee employee);
        public void Update(Employee employee);
        public void Delete(Guid id);
        public bool SaveChanges();
    }
}
