using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultDestinationComponentPartial: ViewComponent
    {
        private readonly IDestinationService _destinationCategory;

        public _DefaultDestinationComponentPartial(IDestinationService destinationCategory)
        {
            _destinationCategory = destinationCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _destinationCategory.GetAllDestinationAsync();
            return View(values);
        }
    }
}
