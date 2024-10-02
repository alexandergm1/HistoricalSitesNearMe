using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Models.PlacesApi
{
    public class HistoricalSite
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
    }
}
