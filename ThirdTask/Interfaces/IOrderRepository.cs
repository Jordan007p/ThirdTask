

using ThirdTask.Models;

namespace ThirdTask.Interfaces
{
    internal interface IOrderRepository
    {
        void AddOrder(Order order);
        ICollection<Order> GetAll();
        ICollection<Order> GetAllOrdersOrderedByDate();
    }
}
