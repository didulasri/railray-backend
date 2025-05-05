namespace RailRay.API.Models.Domain
{
    public class TrainSchedule
    {
        public Guid Id { get; set; }
        public Guid TrainId { get; set; }
        public Guid FromStationId { get; set; }
        public Guid ToStationId { get; set; }

        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public Train? Train { get; set; }
        public Station? FromStation { get; set; }
        public Station? ToStation { get; set; }
        public ICollection<Booking>? Bookings { get; set; }

    }
}
