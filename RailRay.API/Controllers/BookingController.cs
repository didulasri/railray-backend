
using Microsoft.AspNetCore.Mvc;
using RailRay.API.Data;
using RailRay.API.Models.Domain;
using RailRay.API.Models.DTOs;

namespace RailRay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase

    {

        private readonly RailRayDbContext dbContext;

        public BookingController(RailRayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Get all bookings
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = dbContext.Bookings.ToList();

            var dtoList = bookings.Select(b => new BookingDto
            {
                Id = b.Id,
                UserId = b.UserId,
                ScheduleId = b.ScheduleId,
                BookingDate = b.BookingDate,
                Status = b.Status
            }).ToList();

            return Ok(dtoList);
        }



        // GET: Get booking by Id
        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
            var booking = dbContext.Bookings.FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }
            var dto = new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                ScheduleId = booking.ScheduleId,
                BookingDate = booking.BookingDate,
                Status = booking.Status
            };

            return Ok(dto);

        }


        //POST to create a booking
        [HttpPost]
        public IActionResult Create([FromBody] AddBookingRequestDto addBookingRequestDto)
        {
            var booking = new Booking
            {
                UserId = addBookingRequestDto.UserId,
                ScheduleId = addBookingRequestDto.ScheduleId,
                BookingDate = DateTime.UtcNow,
                Status = "Pending"

            };
            dbContext.Bookings.Add(booking);
            dbContext.SaveChanges();

            var bookingDto = new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                ScheduleId = booking.ScheduleId,
                BookingDate = booking.BookingDate,
                Status = booking.Status
            };
            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, bookingDto);

        }


        //DELETE a booking
        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var booking = dbContext.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null) return NotFound();

            dbContext.Bookings.Remove(booking);
            dbContext.SaveChanges();

            return NoContent();
        }



    }
}
