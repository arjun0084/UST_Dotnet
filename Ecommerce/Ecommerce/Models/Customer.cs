using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public int MyProperty { get; set; }

    }
}
