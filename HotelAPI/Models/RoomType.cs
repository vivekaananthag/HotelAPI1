﻿using System;
using System.Collections.Generic;

namespace HotelAPI.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
