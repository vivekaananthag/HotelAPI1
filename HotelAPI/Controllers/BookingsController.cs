#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hotel.Models.DTO;
using Hotel.Interface.Service;

namespace HotelAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private IRoomService _roomService;

        public BookingsController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        /// <summary>
        /// API Method to retrieve a list of bookings
        /// </summary>
        /// <returns></returns>
        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookings()
        {          
            try
            {
                var bookings = await _bookingService.GetBookings();
                return Ok(bookings);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: api/RoomTypes
        [Route("GetRoomTypes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDto>>> GetRoomTypes()
        {
            try
            {
                var roomTypes = await _roomService.GetRoomTypes();
                return Ok(roomTypes);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [Route("AddBooking")]
        [HttpPost]
        public async Task<ActionResult<BookingDto>> PostBooking(AddBookingDto bookingDto)
        {
            try
            {
                var booking = await _bookingService.AddBooking(bookingDto);
                if (booking == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error while adding a room");
                if(!string.IsNullOrEmpty(booking.Message))
                    return StatusCode(StatusCodes.Status400BadRequest, booking.Message);

                return Ok(booking);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }   
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
