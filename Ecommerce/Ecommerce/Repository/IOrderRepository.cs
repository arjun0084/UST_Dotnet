using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
        

    }
}
