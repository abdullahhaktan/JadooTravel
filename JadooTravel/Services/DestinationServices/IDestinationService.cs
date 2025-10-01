using JadooTravel.Dtos.DestinationDtos;

namespace JadooTravel.Services.Services
{
    public interface IDestinationService
    {
        Task<List<ResultDestinationDto>> GetAllDestinationAsync();
        Task<List<ResultDestinationDto>> GetLast5DestinationAsync();
        Task CreateDestinationAsync(CreateDestinationDto createDestinationDto);
        Task UpdateDestinationAsync(UpdateDestinationDto updateDestinationDto);
        Task DeleteDestinationAsync(string id);
        Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id);

    }
}
