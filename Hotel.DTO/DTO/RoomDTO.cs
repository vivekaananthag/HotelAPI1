using System.ComponentModel.DataAnnotations;
namespace Hotel.Models.DTO
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }
        public string RoomType { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        public string RoomNumber { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
    }
}
