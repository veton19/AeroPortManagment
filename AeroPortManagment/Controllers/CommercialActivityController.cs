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
    public class CommercialActivityController : ControllerBase
    {
        private ICommercialActivityRepository _commercialActivityRepository;
        private readonly IMapper _mapper;
        public CommercialActivityController(ICommercialActivityRepository commercialActivityRepository,
            IMapper mapper)
        {
            _commercialActivityRepository = commercialActivityRepository;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "administrator")]
        public ActionResult<List<CommercialActivityDTO>> GetAllCommercialActivity()
        {
            var commercialActivity = _commercialActivityRepository.GetAll();
            var commercialDtos=_mapper.Map<List<CommercialActivityDTO>>(commercialActivity);
            return Ok(commercialDtos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult<CommercialActivityDTO> GetCommercialActivityById(Guid id)
        {
            var selectedCommercialActivity = _commercialActivityRepository.GetCommercialActivityById(id);
            var commercialDtos=_mapper.Map<CommercialActivityDTO>(selectedCommercialActivity);
            return Ok(commercialDtos);
        }

        [HttpPost]
        //[Authorize]
        public ActionResult CreateCommercialActivity([FromBody] CreateCommercialActivityDTO commercialActivityDTO)
        {
            if(commercialActivityDTO == null)
            {
                return BadRequest();
            }
            var commercialDto=_mapper.Map<CommercialActivity>(commercialActivityDTO);
            _commercialActivityRepository.Create(commercialDto);
            _commercialActivityRepository.SaveChanges();
            return new CreatedResult("location", commercialDto.ActivityTime);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult UpdatedCommercialActivity(Guid id, [FromBody] UpdateCommercialActivityDTO updateCommercialDTO)
        {
            if(updateCommercialDTO == null)
            {
                return BadRequest();
            }
            var commercialDto = _mapper.Map<CommercialActivity>(updateCommercialDTO);
            _commercialActivityRepository.Update(commercialDto);
            _commercialActivityRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "administrator")]
        public ActionResult DeleteCommercialActivity(Guid id)
        {
            _commercialActivityRepository.Delete(id);
            return NoContent();
        }
    }
}
