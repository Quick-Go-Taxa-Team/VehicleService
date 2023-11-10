using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MaintenanceRequest {


    public MaintenanceRequest(string type, string vehicleId, string description, string senderName) {
        Type = type;
        VehicleId = vehicleId;
        Description = description;
        SenderName = senderName;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Type { get; set; }
    public string? VehicleId { get; set; }
    public string? Description { get; set; }
    public string? SenderName { get; set; }
    public List<MaintenanceRecord>? MaintenanceRecords { get; set; }
    public List<ImageRecord>? ImageRecords { get; set; }

}