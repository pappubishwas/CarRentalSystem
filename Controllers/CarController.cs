using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Services;
using CarRentalSystem.Models;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRentalService _carRentalService;

        public CarController(ICarRentalService carRentalService)
        {
            _carRentalService = carRentalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableCars()
        {
            var cars = await _carRentalService.GetAvailableCars();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            await _carRentalService.AddCar(car);
            return CreatedAtAction(nameof(GetAvailableCars), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            await _carRentalService.UpdateCar(id, car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRentalService.DeleteCar(id);
            return NoContent();
        }
    }
}
