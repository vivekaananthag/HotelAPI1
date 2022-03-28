using Hotel.Models.DTO;

namespace Hotel.Interface.DAL
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<RoomDto>> GetRooms(DateTime? date);
        Task<RoomDto> AddRoom(AddRoomDto roomDto);
        Task<IEnumerable<RoomTypeDto>> GetRoomTypes();
    }
}
