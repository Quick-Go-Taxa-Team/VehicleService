using Microsoft.Extensions.Options;
using MongoDB.Driver;


public class VehicleServiceMongo : IVehicleService
{
    private readonly IMongoCollection<Vehicle> _collection;

    public VehicleServiceMongo(IConfiguration configuration)
    {
        string connectionString = configuration["connectionstring"] ?? String.Empty;

        var mongoDatabase = new MongoClient(connectionString).GetDatabase("qgt_db");

        _collection = mongoDatabase.GetCollection<Vehicle>("vehicle_collection");
    }

    public async Task CreateVehicle(Vehicle newVehicle) =>
        await _collection.InsertOneAsync(newVehicle);

    public async Task<List<Vehicle>> GetAllVehicles() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Vehicle?> GetVehicle(string registrationNumber) =>
        await _collection.Find(x => x.RegistrationNumber == registrationNumber).FirstOrDefaultAsync();

    public async Task<List<ImageRecord>> PutImageVehicle(List<ImageRecord> imageRecords, string registrationNumber)
    {
        var vehicle = await _collection.Find(x => x.RegistrationNumber == registrationNumber).FirstOrDefaultAsync();
        vehicle.ImageRecords.AddRange(imageRecords);
        return imageRecords;
    }

    /*
        public async Task<List<ImageRecord>> PutImageMaintenanceRequest(List<ImageRecord> imageRecords, string maintenanceRequestId, string registrationNumber) {
            var maintenanceRequest = await _collection.Find(x => x.RegistrationNumber == registrationNumber).Find()
        }

    }*/

    /*public Task<List<ImageRecord>> PutImageVehicle(List<ImageRecord> imageRecords, string registrationNumber);
        public Task<List<ImageRecord>> PutImageMaintenanceRequest(List<ImageRecord> imageRecords, string maintenanceRequestId);
        }*/
    public async Task<List<ImageRecord>> PutImageMaintenanceRecord(List<ImageRecord> imageRecords,
    string registrationNumber, int maintenanceRequestIndex, int maintenanceRecordIndex)
    {
        MaintenanceRecord maintenanceRecord = await GetMaintenanceRecord(registrationNumber, maintenanceRequestIndex, maintenanceRecordIndex);
        maintenanceRecord.ImageRecords.AddRange(imageRecords);

        maintenanceRecord = await GetMaintenanceRecord(registrationNumber, maintenanceRequestIndex, maintenanceRecordIndex);
        return maintenanceRecord.ImageRecords;
    }


    public async Task<MaintenanceRecord> GetMaintenanceRecord(string registrationNumber, int maintenanceRequestIndex, int maintenanceRecordIndex)
    {
        Vehicle vehicle = await GetVehicle(registrationNumber);
        return vehicle.MaintenanceRequests[maintenanceRequestIndex].MaintenanceRecords[maintenanceRecordIndex];

    }
}
