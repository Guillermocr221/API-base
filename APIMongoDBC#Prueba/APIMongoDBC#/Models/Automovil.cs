using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIMongoDBC_.Models
{
    [BsonIgnoreExtraElements]
    public class Automovil
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("Nombre")]
        public string Nombre { get; set; } = String.Empty;

        [BsonElement("Año")]
        public int Año { get; set; } 

    }
}
