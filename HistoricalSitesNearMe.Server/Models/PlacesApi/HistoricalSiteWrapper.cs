using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Models.PlacesApi
{
    public class HistoricalSiteWrapper
    {
        [JsonProperty("properties")]
        public HistoricalSite? HistoricalSite { get; set; }
    }
}
