namespace RailRay.API.Models.Domain
{
    public class BookingSeat
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public string SeatClass { get; set; } = string.Empty; 
        public decimal Price { get; set; }

        public Booking? Booking { get; set; }

    }
}
