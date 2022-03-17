namespace Hotel.Models.Constants

{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public static class ErrorMessages
    {
        public const string NO_ROOMS_AVAILABLE = "We regrest to inform that no rooms ae avilable that match the criteria selected. Please try a different date or a room type.";
        public const string ROOM_BOOKING_SUCCESS = "Thanks for making the booking. Room number {0} has been successfully booked for the selected dates.";
    }
}
