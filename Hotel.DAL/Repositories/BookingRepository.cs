using Hotel.Models.Database;
using Hotel.Interface.DAL;
using Hotel.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Hotel.Models.DTOMapper;
namespace Hotel.DAL.Repositories
{
    public class BookingRepository : IBookingsRepository
    {
        private readonly HotelContext appDbContext;

        public BookingRepository(HotelContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<BookingDto>> GetBookings()
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

        public IEnumerable<RoomDto> GetAvailableRooms(BookingDto bookingDetails)
        {
            var avaialbleRooms = (from r in appDbContext.Rooms
                                  join b in appDbContext.Bookings
                                  on r.RoomId equals b.BookingId into res
                                  from b in res.DefaultIfEmpty()
                                  where bookingDetails.RoomTypeId == r.RoomTypeId 
                                  select new Room { 
                                       RoomId = r.RoomId,
                                      RoomNumber = r.RoomNumber,
                                      RoomType = r.RoomType
                                  }).ToList();
            
            var roomsDto = new List<RoomDto>();
            if (avaialbleRooms != null && avaialbleRooms.Count > 0)
            {
                foreach (var avaialbleRoom in avaialbleRooms)
                {
                    var roomDto = DTOMapper.MapRoomsDBToDto(avaialbleRoom);
                    roomsDto.Add(roomDto);
                }
            }
            return roomsDto;
        }



        public async Task<BookingDto> AddBooking(BookingDto bookingDto)
        {
            if (bookingDto == null) return new BookingDto { Message = "Unable to do booking"};
            var resultObj = new BookingDto();
            var booking = DTOMapper.MapBookingDtoToDB(bookingDto);
            try
            {
                Booking maxBooking = appDbContext.Bookings.OrderByDescending(x => x.BookingId)
                    .FirstOrDefault() ?? new Booking();
               
                booking.BookingId = maxBooking.BookingId + 1;   
                
                var room = await appDbContext.Rooms
                    .FirstOrDefaultAsync(e => e.RoomId == bookingDto.RoomId);
                booking.Room = room ?? new Room();

                var result = await appDbContext.AddAsync(booking);
                await appDbContext.SaveChangesAsync();

                if (result.Entity != null && result.Entity.BookingId > 0)
                {
                    resultObj = DTOMapper.MapBookingDBToDto(result.Entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultObj;
        }
    }
}
