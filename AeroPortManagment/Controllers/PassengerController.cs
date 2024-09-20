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
    public class PassengerController : ControllerBase
    {
        private IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;
        public PassengerController(IPassengerRepository passengerRepository,IMapper mapper)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult<List<PassengerDTO>> GetAll()
        {
            var passenger = _passengerRepository.GetAll();
            var passengerDto=_mapper.Map<List<PassengerDTO>>(passenger);
            return Ok(passengerDto);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult<PassengerDTO> GetById(Guid id)
        {
            var selectedPassenger = _passengerRepository.GetById(id);
            var passengerDto=_mapper.Map<PassengerDTO>(selectedPassenger);
            return Ok(passengerDto);
        }

        [HttpPost]
        //[Authorize(Roles = "user")]
        public ActionResult CreatePassenger([FromBody] CreatePassengerDTO createPassengerDTO)
        {
            if(createPassengerDTO == null)
            {
                return BadRequest();
            }
            var passengerDto = _mapper.Map<Passenger>(createPassengerDTO);
            _passengerRepository.Create(passengerDto);
            _passengerRepository.SaveChanges();
            return new CreatedResult("location", passengerDto.PassportNumber);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult UpdatedPassenger(Guid id, [FromBody] UpdatePassengerDTO updatePassengerDTO)
        {
            if(updatePassengerDTO == null)
            {
                return BadRequest();
            }
            var passengerDto = _mapper.Map<Passenger>(updatePassengerDTO);
            _passengerRepository.Update(passengerDto);
            _passengerRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult DeleteFlight(Guid id)
        {
            _passengerRepository.Delete(id);
            return NoContent();
        }
    }
}
