using AutoMapper;
using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace JadooTravel.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);

            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task<UpdateFeatureDto> GetFeatureAsync()
        {
            var value = await _featureCollection.Find(f => true).FirstOrDefaultAsync();
            return _mapper.Map<UpdateFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            if (updateFeatureDto.FeatureId == null)
            {
                await CreateFeatureAsync(_mapper.Map<CreateFeatureDto>(updateFeatureDto));
            }
            else
            {
                var value = _mapper.Map<Feature>(updateFeatureDto);
                await _featureCollection.FindOneAndReplaceAsync(f=>f.FeatureId == updateFeatureDto.FeatureId, value);
            }
        }
    }
}
