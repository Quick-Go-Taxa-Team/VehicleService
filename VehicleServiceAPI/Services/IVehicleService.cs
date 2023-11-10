public interface IVehicleService {
    public Task<Vehicle> CreateVehicle(Vehicle newVehicle);
    public Task<List<Vehicle>> GetAllVehicles();
    public Task<Vehicle?> GetVehicle(string registrationNumber);
    public Task<List<ImageRecord>> PutImageVehicle(List<ImageRecord> imageRecords, string registrationNumber);
    public Task<List<ImageRecord>> PutImageMaintenanceRequest(List<ImageRecord> imageRecords, string registrationNumber, int maintenanceRequestIndex);
    public Task<List<ImageRecord>> PutImageMaintenanceRecord(List<ImageRecord> imageRecords, string registrationNumber, int maintenanceRequestIndex, int maintenanceRecordIndex);
}