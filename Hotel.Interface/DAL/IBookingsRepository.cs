using Hotel.Models.DTO;
namespace Hotel.Interface.DAL
{
    public interface IBookingsRepository
    {
        Task<IEnumerable<BookingDto>> GetBookings();
        Task<BookingDto> AddBooking(AddBookingDto bookingDto, int RoomId);
        IEnumerable<RoomDto> GetAvailableRooms(AddBookingDto bookingDetails);
    }
}
