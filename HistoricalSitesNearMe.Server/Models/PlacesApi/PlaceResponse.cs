using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Models.PlacesApi
{
    public class PlaceResponse
    {
        [JsonProperty("results")]
        public List<HistoricalSite>? HistoricalSites { get; set; }
    }
}
