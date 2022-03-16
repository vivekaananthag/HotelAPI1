using Hotel.Models.DTO;
namespace Hotel.Interface.DAL
{
    public interface IBookingsRepository
    {
        Task<IEnumerable<BookingDTO>> GetBookings();
        Task<BookingDTO> AddBooking(BookingDTO bookingDto);
    }
}
