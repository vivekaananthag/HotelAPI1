namespace Hotel.Models.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public Guid UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}
