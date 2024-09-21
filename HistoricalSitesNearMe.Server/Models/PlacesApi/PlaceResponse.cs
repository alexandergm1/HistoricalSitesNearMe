using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Models.PlacesApi
{
    public class PlaceResponse
    {
        [JsonProperty("features")]
        public List<HistoricalSiteWrapper>? HistoricalSites { get; set; }
    }
}
