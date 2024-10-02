namespace HistoricalSitesNearMe.Server.Models.PlacesApi
{
    public class Geometry
    {
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
