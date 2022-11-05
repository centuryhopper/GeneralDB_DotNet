using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace PorfolioDB.Models;

// make sure that we dont have exceptions like "Element 'Id' does not match any field or property of class"
// [BsonIgnoreExtraElements]
public class PortfolioContactModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string? Id { get; set; }

    public string? name { get; set; }
    public string? email { get; set; }
    public string? subject { get; set; }
    public string? message { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, name: {name}, email: {email}, subject: {subject}, message: {message}";
    }
}
