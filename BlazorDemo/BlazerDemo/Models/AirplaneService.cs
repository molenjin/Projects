namespace BlazorDemo.Models
{
    public class AirplaneService
    {
        public List<AirplaneViewModel> AirplaneList { get; set; } = new();
        public bool Loaded = false;
    }
}
