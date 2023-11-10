using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ImageRecord {


    public ImageRecord(string imagePath, string description, DateTime date, string sender) {
        ImagePath = imagePath;
        Description = description;
        Date = date;
        Sender = sender;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? ImagePath { get; set; }
    public string Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Sender { get; set; }


    






}