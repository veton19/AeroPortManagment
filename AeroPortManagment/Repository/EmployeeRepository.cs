using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public AeroPortContext _context;
        public EmployeeRepository(AeroPortContext context)
        {
            _context = context;
        }
        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Delete(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            return employee;
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        
    }
}
