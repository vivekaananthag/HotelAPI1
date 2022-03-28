using Hotel.Models.DTO;

namespace Hotel.Interface.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetRooms(DateTime? date);
        Task<RoomDto> AddRoom(AddRoomDto roomDto);
        Task<IEnumerable<RoomTypeDto>> GetRoomTypes();
    }
}
