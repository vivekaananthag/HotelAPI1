using System;
using System.Collections.Generic;

namespace HotelAPI.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public DateTime Created { get; set; }

        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
