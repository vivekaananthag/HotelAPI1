using Hotel.Models.DTO;
namespace Hotel.Interface.Service
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetBookings();
        Task<BookingDto> AddBooking(BookingDto bookingDto);
    }
}
