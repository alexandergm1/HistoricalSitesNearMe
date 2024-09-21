using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Models.PlacesApi
{
    public class HistoricalSite
    {
        [JsonProperty("name")]
        public string? Name { get; set; } = "";
        [JsonProperty("country")]
        public string? Country { get; set; } = "";
        [JsonProperty("state")]
        public string? State { get; set; } = "";
        [JsonProperty("postcode")]
        public string? Postcode { get; set; } = "";
        [JsonProperty("city")]
        public string? City { get; set; } = "";
        [JsonProperty("street")]
        public string? Street { get; set; } = "";
        [JsonProperty("housenumber")]
        public string? HouseNumber { get; set; } = "";
        [JsonProperty("lon")]
        public string? Longitude { get; set; } = "";
        [JsonProperty("lat")]
        public string? Latitude { get; set; } = "";
        [JsonProperty("address_line1")]
        public string? AddressLine1 { get; set; } = "";
        [JsonProperty("address_line2")]
        public string? AddressLine2 { get; set; } = "";
        [JsonProperty("distance")]
        public string? Distance { get; set; } = "";
        [JsonProperty("place_id")]
        public string? PlaceId { get; set; } = "";
    }
}
