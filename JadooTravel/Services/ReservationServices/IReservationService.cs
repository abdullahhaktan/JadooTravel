using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.CategoryDtos;

namespace JadooTravel.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<List<ResultReservationDto>> GetAllReservationAsync();
        Task<List<ResultReservationDto>> GetLast5ReservationAsync();
        Task CreateReservationAsync(CreateReservationDto createReservationDto);
        Task UpdateReservationAsync(UpdateReservationDto updateReservationDto);
        Task DeleteReservationAsync(string id);
        Task<GetReservationByIdDto> GetReservationByIdAsync(string id);
    }
}
