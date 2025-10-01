using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JadooTravel.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialSurname { get; set; }
        public string Comment { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
