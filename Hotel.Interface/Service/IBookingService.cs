using Hotel.Models.DTO;
namespace Hotel.Interface.Service
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetBookings();
        Task<BookingDTO> AddBooking(BookingDTO bookingDto);
    }
}
