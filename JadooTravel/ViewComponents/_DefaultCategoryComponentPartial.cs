using JadooTravel.Entities;
using JadooTravel.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace JadooTravel.ViewComponents
{
    public class _DefaultCategoryComponentPartial:ViewComponent
    {
        private readonly ICategoryService _catgoryservice;

        public _DefaultCategoryComponentPartial(ICategoryService catgoryservice)
        {
            _catgoryservice = catgoryservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _catgoryservice.GetAllCategoryAsync();
            return View(values);
        }
    }
}
