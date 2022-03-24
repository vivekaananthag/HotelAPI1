#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hotel.Models.DTO;
using Hotel.Interface.Service;
using Microsoft.Data.SqlClient;

namespace HotelAPI.Controllers
{
    [Authorize(Roles = Hotel.Models.Constants.UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Rooms        
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {            
            try
            {
                var rooms = await _roomService.GetRooms();
                return Ok(rooms);
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

        [Route("AddRoom")]
        [HttpPost]
        public async Task<ActionResult<RoomDto>> PostRoom(RoomDto roomDto)
        {            
            try
            {
                var room = await _roomService.AddRoom(roomDto);   
                if(room == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error while adding a room");                
                return Ok(room);
            }            
            catch (Exception e)
            {                
                if (e.InnerException is SqlException sqlException
                    && (sqlException.Number == 2627 || sqlException.Number == 2601))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Room number cannot be  duplicate");
                }
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //// DELETE: api/Rooms/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRoom(int id)
        //{
        //    var room = await _context.Rooms.FindAsync(id);
        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Rooms.Remove(room);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RoomExists(int id)
        //{
        //    return _context.Rooms.Any(e => e.RoomId == id);
        //}
    }
}
