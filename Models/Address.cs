using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Models
{
    public class Address
    {
        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("Code")]
        public string Code { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Mobile")]
        public string Mobile { get; set; }
    }
}