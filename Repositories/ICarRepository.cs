using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Models;

public interface ICarRepository
{
    Task<Car> GetCarById(int carId);
    Task<List<Car>> GetAvailableCars();
    Task AddCar(Car car);
    Task UpdateCar(int carId, Car car); 
    Task DeleteCar(int carId); 
}


