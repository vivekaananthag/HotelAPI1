﻿namespace Hotel.Models.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
