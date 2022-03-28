using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DTO
{
    public class AddRoomDto
    {
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
    }
}
