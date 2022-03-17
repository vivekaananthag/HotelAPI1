using Hotel.Interface.Service;
using Hotel.Interface.DAL;
using Hotel.Models.DTO;

namespace Hotel.Service
{
    public class RoomService : IRoomService
    {        
        private IRoomsRepository _roomsRepository;
        
        public RoomService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;            
        }
        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            return await _roomsRepository.GetRooms();
        }
        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            return await _roomsRepository.AddRoom(roomDto);
        }
    }
}