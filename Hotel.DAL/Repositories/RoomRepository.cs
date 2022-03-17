using Hotel.Models.DTO;
using Hotel.Models.Database;
using Hotel.Interface.DAL;
using Microsoft.EntityFrameworkCore;
using Hotel.Models.DTOMapper;

namespace Hotel.DAL.Repositories
{
    public class RoomRepository : IRoomsRepository
    {
        private readonly HotelContext appDbContext;

        public RoomRepository(HotelContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            var rooms = await appDbContext.Rooms.Include(x=>x.RoomType).ToListAsync();
            var roomsDto = new List<RoomDto>();
            if (rooms != null && rooms.Count > 0)
            {
                foreach (var room in rooms)
                {
                    var roomDto = DTOMapper.MapRoomsDBToDto(room);
                    roomsDto.Add(roomDto);
                }
            }
            return roomsDto;
        }

        //public async Task<Employee> GetEmployee(int employeeId)
        //{
        //    return await appDbContext.Employees
        //        .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        //}

        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            if (roomDto == null) return new RoomDto { ErrorMessage = "Unable to add room" };

            var resultObj = new RoomDto();
            var room = DTOMapper.MapRoomsDtoToDB(roomDto);
            try
            {
                Room maxRoom = appDbContext.Rooms.OrderByDescending(x => x.RoomId).FirstOrDefault() ?? new Room();
                var roomTypes = await appDbContext.RoomTypes.ToListAsync();                   

                room.RoomId = maxRoom.RoomId + 1;                
                room.Created = DateTime.Now;                
                room.RoomType = roomTypes.FirstOrDefault(e => e.RoomTypeId == room.RoomTypeId) ?? new RoomType();

                var result = await appDbContext.AddAsync(room);
                await appDbContext.SaveChangesAsync();

                if(result.Entity != null && result.Entity.RoomId > 0)
                {
                    resultObj = DTOMapper.MapRoomsDBToDto(result.Entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return roomDto;
        }

        
    }
}