using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Vehicle {

    public Vehicle (string brand, string model, string registrationNumber, int mileage, List<ImageRecord> imageRecords, List<MaintenanceRequest> maintenanceRequests) {
        Brand = brand;
        Model = model;
        RegistrationNumber = registrationNumber;
        Mileage = mileage;
        ImageRecords = imageRecords;
        MaintenanceRequests = maintenanceRequests;
    }    

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? RegistrationNumber { get; set; }
    public int? Mileage { get; set; }
    public List<MaintenanceRequest>? MaintenanceRequests { get; set; }
    public List<ImageRecord>? ImageRecords { get; set; }


    






}