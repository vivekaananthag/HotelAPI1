using Hotel.Models.Database;
using Hotel.Interface.DAL;
using Hotel.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Hotel.Models.DTOMapper;
using Microsoft.Data.SqlClient;

namespace Hotel.DAL.Repositories
{
    public class BookingRepository : IBookingsRepository
    {
        private readonly HotelContext appDbContext;

        public BookingRepository(HotelContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// DAL method to retrieve a list of bookings
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookingDto>> GetBookings()
        {
            try
            {
                var bookings = await appDbContext.Bookings.ToListAsync();
                var bookingsDto = new List<BookingDto>();
                if (bookings != null && bookings.Count > 0)
                {
                    foreach (var booking in bookings)
                    {
                        var bookingDto = DTOMapper.MapBookingDBToDto(booking);
                        bookingsDto.Add(bookingDto);
                    }
                }
                return bookingsDto;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DAL Method to get a list of available rooms based on booking details
        /// </summary>
        /// <param name="bookingDetails"></param>
        /// <returns></returns>
        public IEnumerable<RoomDto> GetAvailableRooms(AddBookingDto bookingDetails)
        {
            try
            {
                var FromDate = new SqlParameter("FromDate", bookingDetails.FromDate);
                var ToDate = new SqlParameter("ToDate", bookingDetails.ToDate);
                var RoomTypeId = new SqlParameter("RoomTypeId", bookingDetails.RoomTypeId);

                var availableRooms = appDbContext.Rooms
                                        .FromSqlRaw("EXECUTE dbo.GetAvailableRooms @FromDate, @ToDate, @RoomTypeId",
                                        FromDate, ToDate, RoomTypeId).ToList();
               
                var roomsDto = new List<RoomDto>();
                if (availableRooms != null && availableRooms.Count > 0)
                {
                    foreach (var availableRoom in availableRooms)
                    {
                        var roomDto = DTOMapper.MapRoomsDBToDto(availableRoom);
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
        /// DAL Method to add a new booking
        /// </summary>
        /// <param name="bookingDto"></param>
        /// <returns></returns>
        public async Task<BookingDto> AddBooking(AddBookingDto bookingDto, int RoomId)
        {
            try
            {
                if (bookingDto == null) return null;

                var resultObj = new BookingDto();
                var booking = DTOMapper.MapAddBookingDtoToDB(bookingDto);

                var room = await appDbContext.Rooms
                    .FirstOrDefaultAsync(e => e.RoomId == RoomId);
                booking.Room = room ?? new Room();

                var result = await appDbContext.AddAsync(booking);
                appDbContext.Entry(booking.Room).State = EntityState.Detached;
                await appDbContext.SaveChangesAsync();

                if (result.Entity != null && result.Entity.BookingId > 0)
                {
                    resultObj = DTOMapper.MapBookingDBToDto(result.Entity);
                }
                return resultObj;

            }
            catch
            {
                throw;
            }
        }
    }
}
