namespace RailRay.API.Models.DTOs
{
    public class AddBookingRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
    }
}
