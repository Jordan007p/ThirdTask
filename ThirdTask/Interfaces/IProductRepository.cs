
using ThirdTask.Models;

namespace ThirdTask.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        ICollection<Product> GetAll();
        ICollection<Product> GetAllProductsOrderedByMostSold();
    }
}
