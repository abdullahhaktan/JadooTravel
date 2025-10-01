using JadooTravel.Services.CategoryServices;
using JadooTravel.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _catgoryservice;

        public CategoryController(ICategoryService catgoryservice)
        {
            _catgoryservice = catgoryservice;
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _catgoryservice.GetAllCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _catgoryservice.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _catgoryservice.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _catgoryservice.GetCategoryByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _catgoryservice.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("CategoryList");
        }

    }
}
