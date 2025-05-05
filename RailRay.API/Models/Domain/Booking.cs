using System.Net.Sockets;

namespace RailRay.API.Models.Domain
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid ScheduleId { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";

        public User? User { get; set; }
        public TrainSchedule? TrainSchedule { get; set; }
        public ICollection<BookingSeat>? Seats { get; set; }
        public Payment? Payment { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
