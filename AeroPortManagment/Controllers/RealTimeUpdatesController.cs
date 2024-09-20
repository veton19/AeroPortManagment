using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;
using AeroPortManagment.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace AeroPortManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealTimeUpdatesController : ControllerBase
    {
        private IRealTimeUpdateRepository _realTimeUpdateRepository;
        private readonly IMapper _mapper;

        public RealTimeUpdatesController(IRealTimeUpdateRepository realTimeUpdateRepository,IMapper mapper)
        {
            _realTimeUpdateRepository = realTimeUpdateRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<RealTimeUpdateDTO>> GetAllRealTimeUpdate()
        {
            var realTimeUpdate = _realTimeUpdateRepository.GetAll();
            var realTimeDto=_mapper.Map<List<RealTimeUpdateDTO>>(realTimeUpdate);
            return Ok(realTimeDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RealTimeUpdateDTO> GetRealTimeUpdateById(Guid id)
        {
            var selectedRealTimeUpdate = _realTimeUpdateRepository.GetRealTimeUpdatesId(id);
            var realTimeDto=_mapper.Map<RealTimeUpdateDTO>(selectedRealTimeUpdate);
            return Ok(realTimeDto);
        }

        [HttpPost]
        public ActionResult CreateRealTimeUpdate([FromBody] CreateRealTimeUpdate createRealTimeUpdate)
        {
            if(createRealTimeUpdate == null)
            {
                return BadRequest();
            }
            var realTimeDto = _mapper.Map<RealTimeUpdate>(createRealTimeUpdate);
            _realTimeUpdateRepository.Create(realTimeDto);
            _realTimeUpdateRepository.SaveChanges();
            return new CreatedResult("location", realTimeDto.UpdateTime);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatedRealTimeUpdate(Guid id, [FromBody] UpdateRealTimeUpdate updateRealTimeUpdate)
        {
            if(updateRealTimeUpdate == null)
            {
                return BadRequest();
            }
            var realTimeDto = _mapper.Map<RealTimeUpdate>(updateRealTimeUpdate);
            _realTimeUpdateRepository.Update(realTimeDto);
            _realTimeUpdateRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRealTimeUpdate(Guid id)
        {
            _realTimeUpdateRepository.Delete(id);
            return NoContent();
        }
    }
}
