namespace CarRentalSystem.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public decimal Price { get; set; }

        public Car Car { get; set; }
        public User User { get; set; }
    }
}
