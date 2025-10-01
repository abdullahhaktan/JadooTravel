using AutoMapper;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;
using JadooTravel.Services.ReservationServices;

namespace JadooTravel.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservationCollection;
        private readonly IMapper _mapper;

        public ReservationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _reservationCollection = database.GetCollection<Reservation>(_databaseSettings.ReservationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateReservationAsync(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);
            await _reservationCollection.InsertOneAsync(value);
        }

        public async Task DeleteReservationAsync(string id)
        {
            await _reservationCollection.DeleteOneAsync(d => d.ReservationId == id);
        }

        public async Task<List<ResultReservationDto>> GetAllReservationAsync()
        {
            var values = await _reservationCollection.Find(d => true).ToListAsync();
            return _mapper.Map<List<ResultReservationDto>>(values);
        }

        public async Task<GetReservationByIdDto> GetReservationByIdAsync(string id)
        {
            var value = await _reservationCollection.Find(d => d.ReservationId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetReservationByIdDto>(value);
        }

        public async Task<List<ResultReservationDto>> GetLast5ReservationAsync()
        {
            var values = await _reservationCollection.Find(d => true).SortByDescending(d => d.ReservationId).Limit(5).ToListAsync();
            return _mapper.Map<List<ResultReservationDto>>(values);
        }

        public async Task UpdateReservationAsync(UpdateReservationDto updateReservationDto)
        {
            var value = _mapper.Map<Reservation>(updateReservationDto);
            await _reservationCollection.FindOneAndReplaceAsync(d => d.ReservationId == updateReservationDto.ReservationId, value);

        }
    }
}