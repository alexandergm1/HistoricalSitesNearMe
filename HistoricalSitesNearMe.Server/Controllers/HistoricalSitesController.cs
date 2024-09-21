using HistoricalSitesNearMe.Server.Models.PlacesApi;
using HistoricalSitesNearMe.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalSitesNearMe.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HistoricalSitesController : ControllerBase
    {
        PlacesApiService placesApiService;

        public HistoricalSitesController(PlacesApiService placesApiService)
        {
            this.placesApiService = placesApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoricalSitesAsync()
        {
            List<HistoricalSite>? historicalSites = await placesApiService.GetHistoricalSitesAsync();
            if (historicalSites == null)
            {
                return BadRequest("Error occurred retrieving historical site information. Returning BadRequest");
            }
            return Ok(historicalSites);
        }
    }
}
