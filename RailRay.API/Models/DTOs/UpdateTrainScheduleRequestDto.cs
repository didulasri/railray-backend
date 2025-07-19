namespace RailRay.API.Models.DTOs
{
    public class UpdateTrainScheduleRequestDto
    {
        public Guid TrainId { get; set; }
        public Guid FromStationId { get; set; }
        public Guid ToStationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
