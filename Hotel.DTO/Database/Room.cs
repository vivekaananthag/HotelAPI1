using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Database
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public DateTime Created { get; set; }

        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
