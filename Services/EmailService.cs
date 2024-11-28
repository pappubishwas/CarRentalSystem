using CarRentalSystem.Models;

public class CarRentalService : ICarRentalService
{
    private readonly ICarRepository _carRepo;
    private readonly IEmailService _emailService;

    public CarRentalService(ICarRepository carRepo, IEmailService emailService)
    {
        _carRepo = carRepo;
        _emailService = emailService;
    }

    public async Task<bool> RentCar(int carId, int userId)
    {
        var car = await _carRepo.GetCarById(carId);
        if (car != null && car.IsAvailable)
        {
            await _carRepo.UpdateCarAvailability(carId, false);
            await _emailService.SendEmailAsync("pappuovi8@gmail.com", "Booking Confirmed",
                $"Your booking for {car.Make} {car.Model} is confirmed!");
            return true;
        }
        return false;
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
