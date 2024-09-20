using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;
using AeroPortManagment.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroPortManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private ISecurityRepository _securityRepository;
        private readonly IMapper _mapper;
        public SecurityController(ISecurityRepository securityRepository,IMapper mapper) 
        {
            _securityRepository = securityRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<SecurityDTO>> GetAllSecurity()
        {
            var security = _securityRepository.GetAll();
            var securityDto=_mapper.Map<List<SecurityDTO>>(security);
            return Ok(securityDto);
        }

        [HttpGet("{id}")]
        public ActionResult<SecurityDTO> GetSecurityId(Guid id)
        {
            var selectedSecurity = _securityRepository.GetSecurityId(id);
            var securityDto=_mapper.Map<SecurityDTO>(selectedSecurity);
            return Ok(securityDto);
        }

        [HttpPost]
        public ActionResult CreateSecurity([FromBody] CreateSecurity createSecurity)
        {
            if(createSecurity == null)
            {
                return BadRequest();
            }
            var securityDto= _mapper.Map<Security>(createSecurity);
            _securityRepository.Create(securityDto);
            _securityRepository.SaveChanges();
            return new CreatedResult("location", securityDto.CheckStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatedSecurity(Guid id, [FromBody] UpdateSecurity updateSecurity)
        {
            if (updateSecurity == null)
            {
                return BadRequest();
            }
            var securityDto = _mapper.Map<Security>(updateSecurity);
            _securityRepository.Update(securityDto);
            _securityRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSecurity(Guid id)
        {
            _securityRepository.Delete(id);
            return NoContent();
        }
    }
}
