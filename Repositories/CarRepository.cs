public class CarRepository : ICarRepository
{
    private readonly CarRentalDbContext _context;

    public CarRepository(CarRentalDbContext context)
    {
        _context = context;
    }

    public async Task<Car> GetCarById(int carId)
    {
        return await _context.Cars.FindAsync(carId);
    }

    public async Task<List<Car>> GetAvailableCars()
    {
        return await _context.Cars.Where(car => car.IsAvailable).ToListAsync();
    }

    public async Task AddCar(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCar(int carId, Car car)
    {
        var existingCar = await _context.Cars.FindAsync(carId);
        if (existingCar != null)
        {
            // Update properties as needed
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.IsAvailable = car.IsAvailable;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteCar(int carId)
    {
        var car = await _context.Cars.FindAsync(carId);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}
