


using Dapper;
using ThirdTask.Helper;
using ThirdTask.Interfaces;
using ThirdTask.Models;

namespace ThirdTask.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public CategoryRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddCategory(Category category)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@CategoryName, @Description, @Picture)";
                connection.Execute(sql, category);
            }
        }

        public ICollection<Category> GetAllCategories()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM Categories";
                return connection.Query<Category>(sql).ToList();
            }
        }

        public ICollection<Category> GetAllCategoriesOrderedByMostSold()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = @"
                SELECT C.CategoryId, C.CategoryName, C.Description, C.Picture
                FROM Categories C
                JOIN Products P ON C.CategoryId = P.CategoryId
                JOIN OrderDetails OD ON P.ProductId = OD.ProductId
                GROUP BY C.CategoryId, C.CategoryName, C.Description, C.Picture
                ORDER BY SUM(OD.Quantity) DESC";
                return connection.Query<Category>(sql).ToList();
            }
        }
    }

}
