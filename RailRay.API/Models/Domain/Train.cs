namespace RailRay.API.Models.Domain
{
    public class Train
    {
        public Guid Id { get; set; }
        public string TrainNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public ICollection<TrainSchedule>? Schedules { get; set; }


    }
}
