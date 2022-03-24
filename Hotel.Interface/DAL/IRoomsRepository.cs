using Hotel.Models.DTO;

namespace Hotel.Interface.DAL
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<RoomDto>> GetRooms();
        Task<RoomDto> AddRoom(RoomDto roomDto);
        Task<IEnumerable<RoomTypeDto>> GetRoomTypes();
    }
}
