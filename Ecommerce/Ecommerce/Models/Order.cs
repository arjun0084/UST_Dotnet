namespace Ecommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<Product> OrderItems { get; set; }
    }
}
