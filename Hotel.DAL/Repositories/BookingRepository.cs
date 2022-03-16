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

        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            var bookings = await appDbContext.Bookings.Include(x => x.User).ToListAsync();
            var bookingsDto = new List<BookingDTO>();
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

        public async Task<BookingDTO> AddBooking(BookingDTO bookingDto)
        {
            if (bookingDto == null) return new BookingDTO { ErrorMessage = "Unable to do booking"};
            var resultObj = new BookingDTO();
            var booking = DTOMapper.MapBookingDtoToDB(bookingDto);
            try
            {
                Booking maxBooking = appDbContext.Bookings.OrderByDescending(x => x.BookingId)
                    .FirstOrDefault() ?? new Booking();
               
                booking.BookingId = maxBooking.BookingId + 1;                

                var user = await appDbContext.Users
                    .FirstOrDefaultAsync(e => e.UserId == bookingDto.UserId);
                booking.User = user ?? new User();

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
