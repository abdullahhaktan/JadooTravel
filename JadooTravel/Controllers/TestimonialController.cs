using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _categoryTestimonial;

        public TestimonialController(ITestimonialService categoryTestimonial)
        {
            _categoryTestimonial = categoryTestimonial;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _categoryTestimonial.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _categoryTestimonial.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _categoryTestimonial.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var values = await _categoryTestimonial.GetTestimonialByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _categoryTestimonial.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

    }
}
