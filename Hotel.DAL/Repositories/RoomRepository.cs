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

        /// <summary>
        /// Get a list of rooms
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            try
            {
                var rooms = await appDbContext.Rooms.Include(x => x.RoomType).ToListAsync();
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
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DAL Method to retrieve list of room types, like Single, Double etc.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypes()
        {
            try
            {
                var roomTypes = await appDbContext.RoomTypes.ToListAsync();
                var roomTypesDto = new List<RoomTypeDto>();
                if (roomTypes != null && roomTypes.Count > 0)
                {
                    foreach (var roomType in roomTypes)
                    {
                        var roomTypeDto = new RoomTypeDto
                        {
                            RoomTypeId = roomType.RoomTypeId,
                            RoomTypeName = roomType.RoomTypeName
                        };
                        roomTypesDto.Add(roomTypeDto);
                    }
                }
                return roomTypesDto;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DAL Method to add a new room
        /// </summary>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            try
            {
                if (roomDto == null) return null;

                var resultObj = new RoomDto();
                var room = DTOMapper.MapRoomsDtoToDB(roomDto);
                                
                var roomTypes = await appDbContext.RoomTypes.ToListAsync();
                room.RoomType = roomTypes.FirstOrDefault(e => e.RoomTypeId == room.RoomTypeId) ?? new RoomType();

                var result = await appDbContext.AddAsync(room);
                appDbContext.Entry(room.RoomType).State = EntityState.Detached;
                await appDbContext.SaveChangesAsync();

                if (result.Entity != null && result.Entity.RoomId > 0)
                {
                    resultObj = DTOMapper.MapRoomsDBToDto(result.Entity);
                }

                return roomDto;
            }
            catch
            {
                throw;
            }
        }

        
    }
}