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
        public async Task<IActionResult> GetHistoricalSitesAsync([FromQuery] string coordinates, string radius)
        {
            if (coordinates == null)
            {
                return BadRequest("Invalid coordinates received, returning BadRequest");
            }
            List<HistoricalSite>? historicalSites = await placesApiService.GetHistoricalSitesAsync(coordinates, radius);
            if (historicalSites == null)
            {
                return BadRequest("Error occurred retrieving historical site information. Returning BadRequest");
            }
            return Ok(historicalSites);
        }
    }
}
