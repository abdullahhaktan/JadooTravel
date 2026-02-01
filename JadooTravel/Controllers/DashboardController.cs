using JadooTravel.Services.Services;
using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JadooTravel.Controllers
{
    public class DashboardController : Controller
    {
        // Dependency injection for service layers
        private readonly IDestinationService _destinationCategory;
        private readonly ITripPlanService _tripPlanCategory;

        public DashboardController(IDestinationService destinationCategory, ITripPlanService tripPlanCategory)
        {
            _destinationCategory = destinationCategory;
            _tripPlanCategory = tripPlanCategory;
        }

        // Main dashboard action displaying statistics and charts
        public async Task<IActionResult> Index()
        {
            // Get last 5 destinations for recent activity display
            var values = await _destinationCategory.GetLast5DestinationAsync();

            // Get all destinations for statistics and chart data
            var allValues = await _destinationCategory.GetAllDestinationAsync();

            // Prepare data for various dashboard widgets
            ViewBag.Destinations = allValues.Select(x => x.CityCountry).ToList();
            ViewBag.Capacities = allValues.Select(x => x.Capacity).ToList();
            ViewBag.Prices = allValues.Select(x => x.Price).ToList();

            // Prepare data for price distribution chart
            var labels = allValues.Select(x => x.CityCountry).ToList();
            var labelValues = allValues.Select(x => x.Price).ToList();

            // Serialize data for JavaScript chart rendering
            ViewBag.ChartLabels = JsonSerializer.Serialize(labels);
            ViewBag.ChartData = JsonSerializer.Serialize(labelValues);

            // Define price ranges for distribution analysis
            var priceRanges = new[]
            {
                new { Min = 0m, Max = 500m, Label = "0-500₺" },
                new { Min = 501m, Max = 1000m, Label = "501-1000₺" },
                new { Min = 1001m, Max = 2000m, Label = "1001-2000₺" },
                new { Min = 2001m, Max = 5000m, Label = "2001-5000₺" },
                new { Min = 5001m, Max = decimal.MaxValue, Label = "5000+₺" }
            };

            // Calculate count of destinations in each price range
            var priceDistribution = new List<int>();
            foreach (var range in priceRanges)
            {
                var count = allValues.Count(d => d.Price >= range.Min && d.Price <= range.Max);
                priceDistribution.Add(count);
            }

            // Prepare price distribution data for chart
            ViewBag.PriceLabels = priceRanges.Select(r => r.Label).ToList();
            ViewBag.PriceCounts = priceDistribution;

            // Calculate key statistics for dashboard
            ViewBag.TotalDestinations = allValues.Count;
            ViewBag.AveragePrice = allValues.Count > 0 ? allValues.Average(d => d.Price) : 0;
            ViewBag.MaxPrice = allValues.Count > 0 ? allValues.Max(d => d.Price) : 0;
            ViewBag.MaxPriceName = allValues.Where(d => d.Price == ViewBag.MaxPrice).Select(d => d.CityCountry).FirstOrDefault();

            // Return view with last 5 destinations as model
            return View(values);
        }
    }
}