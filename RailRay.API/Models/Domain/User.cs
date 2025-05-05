namespace RailRay.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? NIC { get; set; }
        public string? Passport { get; set; }
        public string PhoneNumber {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

  
        public DateTime LastUpdatedAt { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
       

    }
}
