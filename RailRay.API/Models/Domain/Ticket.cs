namespace RailRay.API.Models.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }

        public string PdfUrl { get; set; } = string.Empty;
        public string QrCodeData { get; set; } = string.Empty;

        public Booking? Booking { get; set; }




    }
}
