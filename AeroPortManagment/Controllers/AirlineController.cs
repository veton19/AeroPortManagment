using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroPortManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;
        public AirlineController(IAirlineRepository airlineRepository,IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult<List<AirlineDTO>> GetAllAirline()
        {
            var airline = _airlineRepository.GetAll();
            var airlineDtos=_mapper.Map<List<AirlineDTO>>(airline);
            return Ok(airlineDtos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult<AirlineDTO> GetAirlineId(Guid id)
        {
            var selectedAirline = _airlineRepository.GetAirlineById(id);
            if(selectedAirline==null)
            {
                return NotFound();
            }
            var airlineDtos = _mapper.Map<AirlineDTO>(selectedAirline);
            return Ok(airlineDtos);
        }

        [HttpPost]
        public ActionResult CreateAirline([FromBody]  CreateAirlineDTO createAirlineDTO)
        {
            if (createAirlineDTO == null)
            {
                return BadRequest();
            }

            var airline = _mapper.Map<Airline>(createAirlineDTO);
            _airlineRepository.Create(airline);
            _airlineRepository.SaveChanges();

            // Setting a meaningful Location header in the response
            return CreatedAtAction(nameof(GetAirlineId), new { id = airline.AirlineId }, createAirlineDTO);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult UpdatedAirline(Guid id, [FromBody] UpdateAirlineDTO updateAirlineDTO)
        {
            if (updateAirlineDTO == null)
            {
                return BadRequest("Airline data is null.");
            }

            var existingAirline = _mapper.Map<Airline>(updateAirlineDTO);
            _airlineRepository.Update(existingAirline);
            _airlineRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public ActionResult DeleteAirline(Guid id)
        {
            var airline = _airlineRepository.GetAirlineById(id);
            if (airline == null)
            {
                return NotFound();
            }

            _airlineRepository.Delete(id);
            _airlineRepository.SaveChanges();

            return NoContent();
        }
    }
}
