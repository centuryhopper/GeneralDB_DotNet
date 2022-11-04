using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

// make sure that we dont have exceptions like "Element 'Id' does not match any field or property of class"
[BsonIgnoreExtraElements]
public class PortfolioContactModel
{
    // [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    // public string id { get; set; }
    public ObjectId _id {get;set;}

    public string name { get; set; }
    public string email { get; set; }
    public string subject { get; set; }
    public string message { get; set; }

    public PortfolioContactModel(string name, string email, string subject, string message)
    {
        this.name = name; this.email = email;
        this.subject = subject; this.message = message;
    }

}
