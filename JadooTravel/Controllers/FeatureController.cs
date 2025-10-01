using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureCategory;

        public FeatureController(IFeatureService featureCategory)
        {
            _featureCategory = featureCategory;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature()
        {
            var value = await _featureCategory.GetFeatureAsync();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureCategory.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("UpdateFeature");
        }

    }
}
