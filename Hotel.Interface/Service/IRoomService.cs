using Hotel.Models.DTO;

namespace Hotel.Interface.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetRooms();
        Task<RoomDto> AddRoom(RoomDto roomDto);
        Task<IEnumerable<RoomTypeDto>> GetRoomTypes();
    }
}
