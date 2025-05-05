namespace RailRay.API.Models.Domain
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid BookingId   { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = "Card";
        public string Status { get; set; } = "Success"; 

        public Booking? Booking { get; set; }
    }
}
