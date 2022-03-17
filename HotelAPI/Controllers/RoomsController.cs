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
    public class RoomsController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Rooms
        [Route("GetRooms")]
        [HttpGet]
        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            return await _roomService.GetRooms();
        }

        //// GET: api/Rooms/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        //{
        //    var room = await _context.Rooms.FindAsync(id);

        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    return room;
        //}

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRoom(int id, Hotel.DTO.DBModels.Room room)
        //{
        //    if (id != room.RoomId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(room).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RoomExists(id))
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

        [Route("AddRoom")]
        [HttpPost]
        public async Task<RoomDto> PostRoom(RoomDto roomDto)
        {
            return await _roomService.AddRoom(roomDto);
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
