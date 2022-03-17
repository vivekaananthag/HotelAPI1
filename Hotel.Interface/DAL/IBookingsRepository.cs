using Hotel.Models.DTO;
namespace Hotel.Interface.DAL
{
    public interface IBookingsRepository
    {
        Task<IEnumerable<BookingDto>> GetBookings();
        Task<BookingDto> AddBooking(BookingDto bookingDto);
        IEnumerable<RoomDto> GetAvailableRooms(BookingDto bookingDetails);
    }
}
