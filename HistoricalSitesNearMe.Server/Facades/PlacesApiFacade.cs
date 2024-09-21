using HistoricalSitesNearMe.Server.Models.PlacesApi;
using Newtonsoft.Json;

namespace HistoricalSitesNearMe.Server.Facades
{
    public class PlacesApiFacade
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PlacesApiFacade(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<HistoricalSite>?> GetHistoricalSitesAsync()
        {
            using HttpClient httpClient = httpClientFactory.CreateClient("PlacesApi");
            HttpResponseMessage response = await httpClient.GetAsync("/v2/places?categories=building.historic&filter=rect%3A10.716463143326969%2C48.755151258420966%2C10.835314015356737%2C48.680903341613316&limit=20&apiKey=c6a283e253fd44e5b25d836bd092a45a");
            
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
