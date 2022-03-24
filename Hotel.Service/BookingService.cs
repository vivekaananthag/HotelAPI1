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
            try
            {
                return await _bookingsRepository.GetBookings();
            }
            catch
            {
                throw;
            }
        }        

        public async Task<BookingDto> AddBooking(AddBookingDto bookingDto)
        {
            try
            {
                var returnObj = new BookingDto();

                //Do date validation
                if (bookingDto == null) return null;

                if (bookingDto.FromDate < DateTime.Now || 
                    bookingDto.FromDate == DateTime.MinValue || bookingDto.FromDate > bookingDto.ToDate)
                    returnObj.Message = Models.Constants.Messages.INVALID_DATE_FROM;

                if (bookingDto.ToDate == DateTime.MinValue)
                    returnObj.Message = Models.Constants.Messages.INVALID_DATE_TO;

                if (string.IsNullOrEmpty(returnObj.Message))
                {
                    //Get lists of available rooms
                    var availableRooms = _bookingsRepository.GetAvailableRooms(bookingDto);

                    //Assign the first room from the list that matches the criteria
                    if (availableRooms != null && availableRooms.ToList().Count > 0)
                    {                        
                        returnObj = await _bookingsRepository.AddBooking(bookingDto, availableRooms.First().RoomId);
                        returnObj.Message = string.Format(Models.Constants.Messages.ROOM_BOOKING_SUCCESS
                                                    , availableRooms.First().RoomNumber);
                    }
                    else
                    {
                        returnObj.Message = Models.Constants.Messages.NO_ROOMS_AVAILABLE;                        
                    }
                }

                return returnObj;
            }
            catch
            {
                throw;
            }
        }
    }
}
