namespace RailRay.API.Models.Domain
{
    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }

        public ICollection<TrainSchedule>? DepartingSchedules { get; set; }
        public ICollection<TrainSchedule>? ArrivingSchedules { get; set; }

    }
}
