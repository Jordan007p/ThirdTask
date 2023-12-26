
using ThirdTask.Models;

namespace ThirdTask.Interfaces
{
    internal interface IOrderDetailsRepository
    {
        void AddOrderDetails(OrderDetails orderDetails);
        ICollection<OrderDetails> GetAll();
    }
}
