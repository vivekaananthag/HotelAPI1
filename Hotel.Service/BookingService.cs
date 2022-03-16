using Hotel.Interface.DAL;
using Hotel.Models.DTO;

namespace Hotel.Service
{
    public class BookingService : IBookingsRepository
    {
        private IBookingsRepository _bookingsRepository;

        public BookingService(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            return await _bookingsRepository.GetBookings();
        }

        public async Task<BookingDTO> AddBooking(BookingDTO bookingDto)
        {
            return await _bookingsRepository.AddBooking(bookingDto);
        }
    }
}
