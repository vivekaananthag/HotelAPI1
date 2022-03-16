namespace Hotel.Models.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomType { get; set; }
        public string RoomName { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
    }
}
