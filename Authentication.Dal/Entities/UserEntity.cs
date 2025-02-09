using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Authentication.Dal.Entities;
public class UserEntity
{
    [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("email"), BsonRepresentation(BsonType.String)]
    public string Email { get; set; }

    [BsonElement("password"), BsonRepresentation(BsonType.String)]
    public string Password { get; set; }

    [BsonElement("salt"), BsonRepresentation(BsonType.String)]
    public string Salt { get; set; }
}
