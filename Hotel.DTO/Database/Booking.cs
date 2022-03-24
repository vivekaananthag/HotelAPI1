using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Database
{
    public partial class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }        
        public int RoomId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime BookingDate { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
