using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace JadooTravel.ViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}