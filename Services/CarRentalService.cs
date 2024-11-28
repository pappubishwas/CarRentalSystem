using CarRentalSystem.Models;

public class CarRentalService : ICarRentalService
{
    private readonly ICarRepository _carRepo;

    public CarRentalService(ICarRepository carRepo)
    {
        _carRepo = carRepo;
    }

    public async Task<bool> CheckCarAvailability(int carId)
    {
        var car = await _carRepo.GetCarById(carId);
        return car != null && car.IsAvailable;
    }

    public async Task<List<Car>> GetAvailableCars()
    {
        return await _carRepo.GetAvailableCars();
    }

    public async Task AddCar(Car car)
    {
        await _carRepo.AddCar(car);  
    }

    public async Task UpdateCar(int carId, Car car)
    {
        await _carRepo.UpdateCar(carId, car); 
    }

    public async Task DeleteCar(int carId)
    {
        await _carRepo.DeleteCar(carId);  
    }
}
