
using Hotel.Models.DTO;
using Hotel.Models.Database;

namespace Hotel.Models.DTOMapper
{
    public static class DTOMapper
    {
        public static RoomDto MapRoomsDBToDto(Room room)
        {
            var roomDto = new RoomDto
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomTypeId = room.RoomTypeId,
                RoomType = room.RoomType != null ? room.RoomType.RoomTypeName : String.Empty
            };
            return roomDto;
        }

        public static Room MapRoomsDtoToDB(RoomDto roomDto)
        {
            var room = new Room
            {
                RoomId = roomDto.RoomId,
                RoomNumber = roomDto.RoomNumber,
                RoomTypeId = roomDto.RoomTypeId
            };
            return room;
        }

        public static BookingDto MapBookingDBToDto(Booking booking)
        {
            return new BookingDto
            {
                BookingId = booking.BookingId,
                BookingDate = booking.BookingDate,
                FromDate = booking.FromDate,
                RoomId = booking.RoomId,
                ToDate = booking.ToDate,
                UserId = booking.UserId,
                RoomDto = booking.Room == null ? new RoomDto() : 
                                                    new RoomDto
                                                    {
                                                        RoomId = booking.Room.RoomId,
                                                        RoomNumber = booking.Room.RoomNumber,
                                                        RoomTypeId = booking.Room.RoomTypeId,
                                                        RoomType = booking.Room.RoomType.RoomTypeName
                                                    }
            };
        }

        public static Booking MapBookingDtoToDB(BookingDto bookingDto)
        {
            return new Booking
            {
                BookingId = bookingDto.BookingId,
                BookingDate = bookingDto.BookingDate,
                FromDate = bookingDto.FromDate,
                RoomId = bookingDto.RoomId,
                ToDate = bookingDto.ToDate,
                UserId = bookingDto.UserId
            };
        }
    }
}
