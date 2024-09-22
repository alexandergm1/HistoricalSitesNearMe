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

        public async Task<List<HistoricalSite>?> GetHistoricalSitesAsync(string locationFilter, string radius)
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("PlacesApi");
            string queryString = $"/maps/api/place/nearbysearch/json?location={locationFilter}&radius={radius}&key={apiKey}&type=landmark";
            
            HttpResponseMessage response = await httpClient.GetAsync(queryString);
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error status code: {response.StatusCode}");
                return null;
            }

            string content = await response.Content.ReadAsStringAsync();
            try
            {
                PlaceResponse? placeResponse = JsonConvert.DeserializeObject<PlaceResponse>(content);
                return placeResponse?.HistoricalSites?.ToList();
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"Error deserialising Json response from Places API. Message: {ex.Message}");
                return null;
            }
        }
    }
}
