using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;

namespace PorfolioDB.Models;

// make sure that we dont have exceptions like "Element 'Id' does not match any field or property of class"
// [BsonIgnoreExtraElements]
public class BookModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string? Id { get; set; }

    public string? title { get; set; }
    public string? author { get; set; }

    [BsonDictionaryOptions(DictionaryRepresentation.Document)]
    public Dictionary<string, object> isbn { get; set; }

    public string? audioBookLink { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, title: {title}, author: {author}, isbn: {String.Join("", isbn)}, audioBookLink: {audioBookLink}";
    }
}
