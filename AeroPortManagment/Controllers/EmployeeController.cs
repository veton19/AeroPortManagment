using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;
using AeroPortManagment.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroPortManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employerepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository repository,IMapper mapper)
        {
            _employerepository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "administrator")]
        public ActionResult<List<EmployeeDTO>> GetAllEmployee()
        {
            var employee = _employerepository.GetAll();
            var employDto=_mapper.Map<List<EmployeeDTO>>(employee);
            return Ok(employDto);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult<EmployeeDTO> GetEmployeeId(Guid id)
        {
            var selectedEmployee = _employerepository.GetEmployeeById(id);
            var employDto=_mapper.Map<EmployeeDTO>(selectedEmployee);
            return Ok(employDto);
        }

        [HttpPost]
        //[Authorize]
        public ActionResult CreateEmployee([FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            if(createEmployeeDTO == null)
            {
                return BadRequest();
            }
            var employDto = _mapper.Map<Employee>(createEmployeeDTO);
            _employerepository.Create(employDto);
            _employerepository.SaveChanges();
            return new CreatedResult("location", employDto.Department);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult UpdatedEmployee(Guid id, [FromBody] UpdateEmployeeDTO updateEmployeeDTO)
        {
            if(updateEmployeeDTO == null)
            {
                return BadRequest();
            }
            var employee = _mapper.Map<Employee>(updateEmployeeDTO);
            _employerepository.Update(employee);
            _employerepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult DeleteEmployee(Guid id)
        {
            _employerepository.Delete(id);
            return NoContent();
        }
    }
}
