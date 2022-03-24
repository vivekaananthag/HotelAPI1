namespace Hotel.Models.Constants

{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public static class Messages
    {
        public const string NO_ROOMS_AVAILABLE = "No rooms available for the selected criteria. Please try a different date or a room type.";
        public const string ROOM_BOOKING_SUCCESS = "Thanks for making the booking. Room number {0} has been successfully booked for the selected dates.";
        public const string INVALID_DATE_TO = "Please select a valid To date";
        public const string INVALID_DATE_FROM = "Please select a valid From date";
    }
}
