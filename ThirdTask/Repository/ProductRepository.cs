
using Dapper;
using ThirdTask.Helper;
using ThirdTask.Interfaces;
using ThirdTask.Models;

namespace ThirdTask.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ProductRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddProduct(Product product)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = @"
                INSERT INTO Products (ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued, LastUserId, LastDateUpdated) 
                VALUES (@ProductName, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued, @LastUserId, @LastDateUpdated)";

                connection.Execute(sql, product);
            }
        }

        public ICollection<Product> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM Products";
                return connection.Query<Product>(sql).ToList();
            }
        }

        public ICollection<Product> GetAllProductsOrderedByMostSold()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = @"
                SELECT P.ProductId, P.ProductName, P.SupplierId, P.CategoryId, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, P.ReorderLevel, P.Discontinued, P.LastUserId, P.LastDateUpdated
                FROM Products P
                JOIN OrderDetails OD ON P.ProductId = OD.ProductId
                GROUP BY P.ProductId, P.ProductName, P.SupplierId, P.CategoryId, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, P.ReorderLevel, P.Discontinued, P.LastUserId, P.LastDateUpdated
                ORDER BY SUM(OD.Quantity) DESC";

                return connection.Query<Product>(sql).ToList();
            }
        }
    }
}
