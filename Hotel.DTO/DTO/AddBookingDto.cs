using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.DTO
{
    public class AddBookingDto
    {
        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "From date is required")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "To date is required")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        public string UserId { get; set; }        
        public string Message { get; set; }
    }
}
