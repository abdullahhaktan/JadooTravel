using JadooTravel.Dtos.TripPlansDtos;
using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class TripPlanController : Controller
    {
        private readonly ITripPlanService _tripPlanService;

        public TripPlanController(ITripPlanService tripPlanService)
        {
            _tripPlanService = tripPlanService;
        }

        public async Task<IActionResult> TripPlanList()
        {
            var values = await _tripPlanService.GetAllTripPlanAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTripPlan()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTripPlan(CreateTripPlanDto createTripPlanDto)
        {
            await _tripPlanService.CreateTripPlanAsync(createTripPlanDto);
            return RedirectToAction("TripPlanList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTripPlan(string id)
        {
            await _tripPlanService.DeleteTripPlanAsync(id);
            return RedirectToAction("TripPlanList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTripPlan(string id)
        {
            var values = await _tripPlanService.GetTripPlanByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTripPlan(UpdateTripPlanDto updateTripPlanDto)
        {
            await _tripPlanService.UpdateTripPlanAsync(updateTripPlanDto);
            return RedirectToAction("TripPlanList");
        }

    }
}
