using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MaintenanceRecord {


    public MaintenanceRecord(DateTime timestamp, string providerName, string description) {
        Timestamp = timestamp;
        ProviderName = providerName;
        Description = description;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime? Timestamp { get; set; }
    public string? ProviderName { get; set; }
    public string? Description { get; set; }
    public List<ImageRecord>? ImageRecords { get; set; }


}