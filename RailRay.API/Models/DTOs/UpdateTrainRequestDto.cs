namespace RailRay.API.Models.DTOs
{
    public class UpdateTrainRequestDto
    {
        public string TrainNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
