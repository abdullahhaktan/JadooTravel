using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.FeatureDtos;

namespace JadooTravel.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<UpdateFeatureDto> GetFeatureAsync();
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    }
}
