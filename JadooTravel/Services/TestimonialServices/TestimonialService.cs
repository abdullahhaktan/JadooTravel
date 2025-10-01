﻿using AutoMapper;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTestimonialAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(c => c.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var values = await _testimonialCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(c => c.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            return _testimonialCollection.ReplaceOneAsync(c => c.TestimonialId == updateTestimonialDto.TestimonialId, value);
        }
    }
}
