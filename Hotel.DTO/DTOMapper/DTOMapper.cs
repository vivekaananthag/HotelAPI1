using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Models.DTO;
using Hotel.Models.Database;

namespace Hotel.Models.DTOMapper
{
    public static class DTOMapper
    {
        public static RoomDTO MapRoomsDBToDto(Room room)
        {
            var roomDto = new RoomDTO
            {
                RoomId = room.RoomId,
                RoomName = room.RoomName,
                RoomTypeId = room.RoomTypeId,
                RoomType = room.RoomType != null ? room.RoomType.RoomTypeName : String.Empty
            };
            return roomDto;
        }

        public static Room MapRoomsDtoToDB(RoomDTO roomDto)
        {
            var room = new Room
            {
                RoomId = roomDto.RoomId,
                RoomName = roomDto.RoomName,
                RoomTypeId = roomDto.RoomTypeId
            };
            return room;
        }

        public static BookingDTO MapBookingDBToDto(Booking booking)
        {
            return new BookingDTO
            {
                BookingId = booking.BookingId,
                BookingDate = booking.BookingDate,
                FromDate = booking.FromDate,
                RoomId = booking.RoomId,
                ToDate = booking.ToDate,
                UserId = booking.UserId
            };
        }

        public static Booking MapBookingDtoToDB(BookingDTO bookingDto)
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
