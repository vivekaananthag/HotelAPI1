using Hotel.Interface.DAL;
using Hotel.Models.DTO;

namespace Hotel.Service
{
    public class RoomService : IRoomsRepository
    {        
        private IRoomsRepository _roomsRepository;
        
        public RoomService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;            
        }
        public async Task<IEnumerable<RoomDTO>> GetRooms()
        {
            return await _roomsRepository.GetRooms();
        }
        public async Task<RoomDTO> AddRoom(RoomDTO roomDto)
        {
            return await _roomsRepository.AddRoom(roomDto);
        }
    }
}