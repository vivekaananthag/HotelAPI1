using Hotel.Interface.Service;
using Hotel.Interface.DAL;
using Hotel.Models.DTO;

namespace Hotel.Service
{
    public class BookingService : IBookingService
    {
        private IBookingsRepository _bookingsRepository;

        public BookingService(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public async Task<IEnumerable<BookingDto>> GetBookings()
        {
            return await _bookingsRepository.GetBookings();
        }

        public async Task<BookingDto> AddBooking(BookingDto bookingDto)
        {
            var returnObj = new BookingDto();
            //Get lists of available rooms
            var availableRooms = _bookingsRepository.GetAvailableRooms(bookingDto);

            //Assign the first room from the list that matches the criteria
            if (availableRooms != null && availableRooms.ToList().Count > 0)
            {
                bookingDto.RoomId = availableRooms.First().RoomId;
                returnObj = await _bookingsRepository.AddBooking(bookingDto);
                returnObj.Message = string.Format(Models.Constants.ErrorMessages.ROOM_BOOKING_SUCCESS
                                            , availableRooms.First().RoomNumber);
            }
            else
            {
                bookingDto.Message = Models.Constants.ErrorMessages.NO_ROOMS_AVAILABLE;
                returnObj = bookingDto;
            }

            return returnObj;
        }
    }
}
