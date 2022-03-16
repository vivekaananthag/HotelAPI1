namespace Hotel.Models.Database
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public DateTime LastLogin { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
