using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationCategory;

        public DestinationController(IDestinationService destinationCategory)
        {
            _destinationCategory = destinationCategory;
        }

        public async Task<IActionResult> DestinationList()
        {
            var values = await _destinationCategory.GetAllDestinationAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDestination()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationDto createDestinationDto)
        {
            await _destinationCategory.CreateDestinationAsync(createDestinationDto);
            return RedirectToAction("DestinationList");
        }
        public async Task<IActionResult> DeleteDestination(string id)
        {
            await _destinationCategory.DeleteDestinationAsync(id);
            return RedirectToAction("DestinationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDestination(string id)
        {
            var value = await _destinationCategory.GetDestinationByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDestination(UpdateDestinationDto updateDestinationDto)
        {
            await _destinationCategory.UpdateDestinationAsync(updateDestinationDto);
            return RedirectToAction("DestinationList");
        }
    }
}
