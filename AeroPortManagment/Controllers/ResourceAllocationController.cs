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
    public class ResourceAllocationController : ControllerBase
    {
        private IResourceAllocationRepository _resourceAllocationRepository;
        private readonly IMapper _mapper;
        public ResourceAllocationController(IResourceAllocationRepository resourceAllocationRepository,
            IMapper mapper)
        {
            _resourceAllocationRepository = resourceAllocationRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<ResourceAllocationDTO>> GetAllResourceAllocation()
        {
            var resourceAllocation =_resourceAllocationRepository.GetAll();
            var resourceDto=_mapper.Map<List<ResourceAllocationDTO>>(resourceAllocation);
            return Ok(resourceDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ResourceAllocationDTO> GetResourceAllocationId(Guid id)
        {
            var selectedResourceAllocation = _resourceAllocationRepository.GetResourceById(id);
            var resourceDto=_mapper.Map<ResourceAllocationDTO>(selectedResourceAllocation);
            return Ok(resourceDto);
        }

        [HttpPost]
        public ActionResult CreateResourceAllocation([FromBody] CreateResourceAllocation createResourceAllocation)
        {
            if(createResourceAllocation == null)
            {
                return BadRequest();
            }
            var resourceDto = _mapper.Map<ResourceAllocation>(createResourceAllocation);
            _resourceAllocationRepository.Create(resourceDto);
            _resourceAllocationRepository.SaveChanges();
            return new CreatedResult("location", resourceDto.AllocationTime);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatedResourceAllocation(Guid id, [FromBody] UpdateResourceAllocation updateResourceAllocation)
        {
            if(updateResourceAllocation == null)
            {
                return BadRequest();
            }
            var resourceDto = _mapper.Map<ResourceAllocation>(updateResourceAllocation);
            _resourceAllocationRepository.Update(resourceDto);
            _resourceAllocationRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteResourceAllocation(Guid id)
        {
            _resourceAllocationRepository.Delete(id);
            return NoContent();
        }
    }
}
