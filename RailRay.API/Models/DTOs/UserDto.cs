namespace RailRay.API.Models.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
