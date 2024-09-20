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
    public class AirportController : ControllerBase
    {
        private IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        public AirportController(IAirportRepository airportRepository,IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult<List<AirlineDTO>> GetAllAirport()
        {
            var airport = _airportRepository.GetAll();
            var airportDtos = _mapper.Map<List<AirportDTO>>(airport);
            return Ok(airportDtos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult<AirportDTO> GetAirportId(Guid id)
        {
            var selectedAirport = _airportRepository.GetAirportById(id);
            if(selectedAirport==null)
            {
                return NotFound();
            }
            var airportDtos=_mapper.Map<AirportDTO>(selectedAirport);
            return Ok(airportDtos);
        }

        [HttpPost]
        //[Authorize]
        public ActionResult CreateAirport([FromBody] CreateAirportDTO createAirportDto)
        {
            if(createAirportDto==null)
            {
                return BadRequest();
            }
            var airport = _mapper.Map<Airport>(createAirportDto);
            _airportRepository.Create(airport);
            _airportRepository.SaveChanges();
            return new CreatedResult("location", airport.Name);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult UpdatedAirport(Guid id, [FromBody] UpdateAirportDTO updateAirportDto)
        {
            if(updateAirportDto==null)
            {
                return BadRequest(); 
            }
            var airport = _mapper.Map<Airport>(updateAirportDto);
            _airportRepository.Update(airport);
            _airportRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult DeleteAirport(Guid id)
        {
            _airportRepository.Delete(id);
            return NoContent();
        }
    }
}
