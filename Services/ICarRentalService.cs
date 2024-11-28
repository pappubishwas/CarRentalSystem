using CarRentalSystem.Models;
using CarRentalSystem.Services;
public interface ICarRentalService
{
    Task<bool> RentCar(int carId, int userId);
    Task<bool> CheckCarAvailability(int carId);
    Task<List<Car>> GetAvailableCars();  
    Task AddCar(Car car);                
    Task UpdateCar(int carId, Car car);  
    Task DeleteCar(int carId);           
}
