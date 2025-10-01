using JadooTravel.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        private readonly IFeatureService _featureCategory;

        public _DefaultFeatureComponentPartial(IFeatureService featureCategory)
        {
            _featureCategory = featureCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _featureCategory.GetFeatureAsync();
            return View(value);
        }
    }
}
