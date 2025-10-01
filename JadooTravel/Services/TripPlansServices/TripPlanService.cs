using AutoMapper;
using JadooTravel.Dtos.TripPlansDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.TripPlanServices
{
    public class TripPlanService : ITripPlanService
    {
        private readonly IMongoCollection<TripPlan> _testimonialCollection;
        private readonly IMapper _mapper;

        public TripPlanService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<TripPlan>(_databaseSettings.TripPlanCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTripPlanAsync(CreateTripPlanDto createTripPlanDto)
        {
            var value = _mapper.Map<TripPlan>(createTripPlanDto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTripPlanAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(c => c.TripPlanId == id);
        }

        public async Task<List<ResultTripPlanDto>> GetAllTripPlanAsync()
        {
            var values = await _testimonialCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultTripPlanDto>>(values);
        }

        public async Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(c => c.TripPlanId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTripPlanByIdDto>(value);
        }

        public Task UpdateTripPlanAsync(UpdateTripPlanDto updateTripPlanDto)
        {
            var value = _mapper.Map<TripPlan>(updateTripPlanDto);
            return _testimonialCollection.ReplaceOneAsync(c => c.TripPlanId == updateTripPlanDto.TripPlanId, value);
        }
    }
}
