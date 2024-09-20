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
    public class BookingController : ControllerBase
    {
        private IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public BookingController(IBookingRepository bookingRepository,IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult<List<BookingDTO>> GetAllBooking()
        {
            var booking = _bookingRepository.GetAll();
            var bookingDtos = _mapper.Map<List<BookingDTO>>(booking);
            return Ok(bookingDtos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public ActionResult<BookingDTO> GetBookingById(Guid id)
        {
            var selectedBooking = _bookingRepository.GetBookingById(id);
            var bookingDtos=_mapper.Map<BookingDTO>(selectedBooking);
            return Ok(bookingDtos);
        }

        [HttpPost]
        //[Authorize]
        public ActionResult CreateBooking([FromBody] CreateBookingDTO createBookingDTO)
        {
            if(createBookingDTO == null)
            {
                return BadRequest();
            }
            var booking = _mapper.Map<Booking>(createBookingDTO);
            _bookingRepository.Create(booking);
            _bookingRepository.SaveChanges();
            return new CreatedResult("location", booking.Passenger);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public ActionResult UpdatedBooking(Guid id, [FromBody] UpdateBookingDTO updateBookingDTO)
        {
            if (updateBookingDTO == null)
            {
                return BadRequest();
            }
            var booking = _mapper.Map<Booking>(updateBookingDTO);
            _bookingRepository.Update(booking);
            _bookingRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public ActionResult DeleteBooking(Guid id)
        {
            _bookingRepository.Delete(id);
            return NoContent();
        }
    }
}
