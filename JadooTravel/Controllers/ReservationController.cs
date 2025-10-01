using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _catgoryservice;

        public ReservationController(IReservationService catgoryservice)
        {
            _catgoryservice = catgoryservice;
        }

        public async Task<IActionResult> ReservationList()
        {
            var values = await _catgoryservice.GetAllReservationAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            await _catgoryservice.CreateReservationAsync(createReservationDto);
            TempData["SuccessMessage"] = "Rezervasyon başarı ile kaydedildi";
            return RedirectToAction("Index","Default");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            await _catgoryservice.DeleteReservationAsync(id);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(string id)
        {
            var values = await _catgoryservice.GetReservationByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            await _catgoryservice.UpdateReservationAsync(updateReservationDto);
            return RedirectToAction("ReservationList");
        }

    }
}
