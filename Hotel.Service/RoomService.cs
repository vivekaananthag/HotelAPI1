using Hotel.Interface.Service;
using Hotel.Interface.DAL;
using Hotel.Models.DTO;
using Microsoft.Data.SqlClient;

namespace Hotel.Service
{
    public class RoomService : IRoomService
    {        
        private IRoomsRepository _roomsRepository;
        
        public RoomService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;            
        }
        public async Task<IEnumerable<RoomDto>> GetRooms(DateTime? date)
        {
            try
            {
                return await _roomsRepository.GetRooms(date);
            }
            catch
            {                
                throw;
            }
        }
        public async Task<RoomDto> AddRoom(AddRoomDto roomDto)
        {
            try
            {
                return await _roomsRepository.AddRoom(roomDto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypes()
        {
            try
            {
                return await _roomsRepository.GetRoomTypes();
            }
            catch
            {
                throw;
            }
        }
    }
}