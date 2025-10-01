using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialCategory;

        public _DefaultTestimonialComponentPartial(ITestimonialService testimonialCategory)
        {
            _testimonialCategory = testimonialCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialCategory.GetAllTestimonialAsync();

            ViewBag.AirlineIcon = "/images/airlines.png";
            ViewBag.ExchangeOfficeIcon = "/images/exchange.png";
            ViewBag.HospitalIcon = "/images/hospital.png";

            return View(values);
        }
    }
}
