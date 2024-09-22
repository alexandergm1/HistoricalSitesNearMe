using HistoricalSitesNearMe.Server.Facades;
using HistoricalSitesNearMe.Server.Models.PlacesApi;

namespace HistoricalSitesNearMe.Server.Services
{
    public class PlacesApiService
    {
        private readonly PlacesApiFacade placesApiFacade;

        public PlacesApiService(PlacesApiFacade placesApiFacade)
        {
            this.placesApiFacade = placesApiFacade;
        }

        public async Task<List<HistoricalSite>?> GetHistoricalSitesAsync(string coordinates, string radius)
        {
            string[] splitCoordinates = coordinates.Split(':');
            string radiusFilter = $"circle:{splitCoordinates.First()},{splitCoordinates.Last()},{radius}";
            return await placesApiFacade.GetHistoricalSitesAsync(radiusFilter);
        }
    }
}
