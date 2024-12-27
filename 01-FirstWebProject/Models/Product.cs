namespace _01_FirstWebProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
