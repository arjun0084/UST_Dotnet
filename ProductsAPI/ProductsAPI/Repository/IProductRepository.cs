using ProductsAPI.Models;
using ProductsAPI.Controllers;
namespace ProductsAPI.NewFolder
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int ProductId);
        void InsertProduct(Product product);

        void DeleteProduct(int productId);

        void UpdateProduct(Product product);

        void Save();

    }
}
