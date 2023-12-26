
using Dapper;
using ThirdTask.Helper;
using ThirdTask.Interfaces;
using ThirdTask.Models;

namespace ThirdTask.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public OrderDetailsRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = @"
                INSERT INTO OrderDetails (OrderId, ProductId, UnitPrice, Quantity, Discount) 
                VALUES (@OrderId, @ProductId, @UnitPrice, @Quantity, @Discount)";

                connection.Execute(sql, orderDetails);
            }
        }

        public ICollection<OrderDetails> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM OrderDetails";
                return connection.Query<OrderDetails>(sql).ToList();
            }
        }
    }
}
