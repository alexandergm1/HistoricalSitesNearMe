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

        public async Task<List<HistoricalSite>?> GetHistoricalSitesAsync()
        {
            return await placesApiFacade.GetHistoricalSitesAsync();
        }
    }
}
