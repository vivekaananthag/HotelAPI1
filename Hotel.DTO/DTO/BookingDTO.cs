using System.ComponentModel.DataAnnotations;
namespace Hotel.Models.DTO
{
    public class BookingDto
    {
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }   
        
        [Required(ErrorMessage = "From date is required")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "To date is required")]
        public DateTime ToDate { get; set; }

        public string UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomId { get; set; }
        public string Message { get; set; }

        public RoomDto RoomDto { get; set; }
    }
}
