#nullable disable
using Microsoft.AspNetCore.Mvc;
using Hotel.Models.DTO;
using Hotel.Interface.Service;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            return await _bookingService.GetBookings();
        }

        // GET: api/Bookings/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Hotel.DTO.DBModels.Booking>> GetBooking(int id)
        //{
        //    var booking = await _context.Bookings.FindAsync(id);

        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return booking;
        //}

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBooking(int id, Hotel.DTO.DBModels.Booking booking)
        //{
        //    if (id != booking.BookingId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(booking).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookingExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BookingDTO> PostBooking(BookingDTO bookingDto)
        {
            return await _bookingService.AddBooking(bookingDto);
        }

        // DELETE: api/Bookings/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBooking(int id)
        //{
        //    var booking = await _context.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Bookings.Remove(booking);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BookingExists(int id)
        //{
        //    return _context.Bookings.Any(e => e.BookingId == id);
        //}
    }
}
