namespace RailRay.API.Models.DTOs
{
    public class UpdateUserRequestDto
    {
        public string? Title { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NIC { get; set; }
        public string? Passport { get; set; }
    }
}
