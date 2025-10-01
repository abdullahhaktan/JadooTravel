using AutoMapper;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Entities;
using JadooTravel.Services.Services;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.DestinationServices
{
    public class DestinationService : IDestinationService
    {
        private readonly IMongoCollection<Destination> _destinationCollection;
        private readonly IMapper _mapper;

        public DestinationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _destinationCollection = database.GetCollection<Destination>(_databaseSettings.DestinationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDestinationAsync(CreateDestinationDto createDestinationDto)
        {
            var value = _mapper.Map<Destination>(createDestinationDto);
            await _destinationCollection.InsertOneAsync(value);
        }

        public async Task DeleteDestinationAsync(string id)
        {
            await _destinationCollection.DeleteOneAsync(d => d.DestinationId == id);
        }

        public async Task<List<ResultDestinationDto>> GetAllDestinationAsync()
        {
            var values = await _destinationCollection.Find(d => true).ToListAsync();
            return _mapper.Map<List<ResultDestinationDto>>(values);
        }

        public async Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id)
        {
            var value = await _destinationCollection.Find(d => d.DestinationId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetDestinationByIdDto>(value);
        }

        public async Task<List<ResultDestinationDto>> GetLast5DestinationAsync()
        {
            var values = await _destinationCollection.Find(d => true).SortByDescending(d=>d.DestinationId).Limit(5).ToListAsync();
            return _mapper.Map<List<ResultDestinationDto>>(values);
        }

        public async Task UpdateDestinationAsync(UpdateDestinationDto updateDestinationDto)
        {
            var value = _mapper.Map<Destination>(updateDestinationDto);
            await _destinationCollection.FindOneAndReplaceAsync(d => d.DestinationId == updateDestinationDto.DestinationId, value);

        }
    }
}