namespace Hackathon_2024_API.Controllers
{
    public class GetMapBox
    {
        public string? name { get; set; }
        public string? name_preferred { get; set; }
        public string? mapbox_id { get; set; }
        public string? feature_type { get; set; }
        public string? address { get; set; }
        public string? full_address { get; set; }
        public string? place_formatted { get; set; }
        public string? language { get; set; }
        public string? maki { get; set; }
        public Dictionary<string, object> metadata { get; set; }
    }
}
