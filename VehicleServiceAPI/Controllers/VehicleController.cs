using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
namespace VehicleServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly ILogger<VehicleController> _logger;
    // private readonly IMemoryCache _memoryCache;

    public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
    {
        _logger = logger;
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles() {
        List<Vehicle> vehicles = await _vehicleService.GetAllVehicles();
        _logger.LogInformation("All vehicles were requested");
        return Ok(vehicles);
    } 

    [HttpGet("{registrationNumber}")]
    public async Task<IActionResult>? GetVehicle(string registrationNumber)
    {
        var vehicle = await _vehicleService.GetVehicle(registrationNumber);
        _logger.LogInformation($"Vehicle with registration number {registrationNumber} was requested");
        return Ok(vehicle);

    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle(Vehicle newVehicle)
    {
        await _vehicleService.CreateVehicle(newVehicle);
        _logger.LogInformation($"Vehicle with registration number {newVehicle.RegistrationNumber} was created");
        return Ok();
    }

    /*
    [HttpPost("{registrationNumber}/images")]
    public async Task<IActionResult> AddImageRecord(string registrationNumber, ImageRecord imageRecord)
    {
        await _vehicleService.AddImageRecord(registrationNumber, imageRecord);
        _logger.LogInformation($"Image record was added to vehicle with registration number {registrationNumber}");
        return Ok();
    }
    */
}