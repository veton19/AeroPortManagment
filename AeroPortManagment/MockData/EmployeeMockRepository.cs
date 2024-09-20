using AeroPortManagment.Interface;
using AeroPortManagment.Models;

namespace AeroPortManagment.MockData
{
    public class EmployeeMockRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public EmployeeMockRepository()
        {
            _employees = new List<Employee>
            {
                new Employee()
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Position = "Security Officer",
                    Department = "Security",
                    AirportId = Guid.NewGuid(),
                    ContactDetails = "john.doe@airport.com",
                },
                new Employee()
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    Position = "Customer Service Agent",
                    Department = "Customer Service",
                    AirportId = Guid.NewGuid(),
                    ContactDetails = "jane.smith@airport.com",
                },
                new Employee()
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Position = "Flight Attendant",
                    Department = "Flight Operations",
                    AirportId = Guid.NewGuid(),
                    ContactDetails = "bob.johnson@airport.com",
                }
            };
        }
        public void Create(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(Guid id)
        {
            var employees=GetEmployeeById(id);
            if(employees!=null)
            {
                _employees.Remove(employees);
            }
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetEmployeeById(Guid id)
        {
            var employees=_employees.First(x=>x.EmployeeId==id);
            return employees;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void Update(Employee employee)
        {
            var updatedEmployees= GetEmployeeById(employee.EmployeeId);
            if(updatedEmployees!=null)
            {
                updatedEmployees.Position = employee.Position;
                updatedEmployees.Department = employee.Department;
                updatedEmployees.ContactDetails = employee.ContactDetails;
            }
        }
    }
}
