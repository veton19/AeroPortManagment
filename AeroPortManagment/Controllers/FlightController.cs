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
    public class FlightController : ControllerBase
    {
        private IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        public FlightController(IFlightRepository flightRepository,IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult<List<FlightDTO>> GetAllFlight()
        {
            var flight = _flightRepository.GetAll();
            var flightDto=_mapper.Map<List<FlightDTO>>(flight);
            return Ok(flightDto);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult<FlightDTO> GetFlightId(Guid id) 
        {
            var selectedFlight=_flightRepository.GetFlightById(id);
            var flightDto=_mapper.Map<FlightDTO>(selectedFlight);
            return Ok(flightDto);
        }

        [HttpPost]
        //[Authorize]
        public ActionResult CreateFlight([FromBody] CreateFlightDTO createFlightDTO)
        {
            if(createFlightDTO == null)
            {
                return BadRequest();
            }
            var flightDto = _mapper.Map<Flight>(createFlightDTO);
            _flightRepository.Create(flightDto);
            _flightRepository.SaveChanges();
            return new CreatedResult("location", flightDto.Destination);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult UpdatedFlight(Guid id, [FromBody] UpdateFlightDTO updateFlightDTO)
        {
            if(updateFlightDTO == null)
            {
                return BadRequest();
            }
            var flightDto = _mapper.Map<Flight>(updateFlightDTO);
            _flightRepository.Update(flightDto);
            _flightRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult DeleteFlight(Guid id)
        {
            _flightRepository.Delete(id);
            return NoContent();
        }
    }
}
