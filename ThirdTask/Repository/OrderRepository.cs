
using Dapper;
using ThirdTask.Helper;
using ThirdTask.Interfaces;
using ThirdTask.Models;

namespace ThirdTask.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public OrderRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddOrder(Order order)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = @"
                INSERT INTO Orders (CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) 
                VALUES (@CustomerId, @EmployeeId, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";

                connection.Execute(sql, order);
            }
        }

        public ICollection<Order> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM Orders";
                return connection.Query<Order>(sql).ToList();
            }
        }

        public ICollection<Order> GetAllOrdersOrderedByDate()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT * FROM Orders ORDER BY OrderDate DESC";
                return connection.Query<Order>(sql).ToList();
            }
        }
    }
}
