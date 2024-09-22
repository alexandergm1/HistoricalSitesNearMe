using HistoricalSitesNearMe.Server.Models.PlacesApi;
using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Facades
{
    public class PlacesApiFacade
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string apiKey;

        public PlacesApiFacade(IHttpClientFactory httpClientFactory, string apiKey)
        {
            this.httpClientFactory = httpClientFactory;
            this.apiKey = apiKey;
        }

        public async Task<List<HistoricalSite>?> GetHistoricalSitesAsync(string radiusFilter)
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("PlacesApi");
            HttpResponseMessage response = await httpClient.GetAsync($"/v2/places?categories=building.historic&filter={radiusFilter}&limit=20&apiKey={apiKey}");
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error status code: {response.StatusCode}");
                return null;
            }

            string content = await response.Content.ReadAsStringAsync();
            try
            {
                PlaceResponse? placeResponse = JsonConvert.DeserializeObject<PlaceResponse>(content);
                return placeResponse?.HistoricalSites?.Select(hs => hs.HistoricalSite).ToList();
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"Error deserialising Json response from Places API. Message: {ex.Message}");
                return null;
            }
        }
    }
}
