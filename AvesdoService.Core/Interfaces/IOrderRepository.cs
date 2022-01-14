using AvesdoService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Interfaces
{
    public interface IOrderRepository<T> where T : IModel<int>
    {
        Task<IEnumerable<T>> GetOrdersAsync();
        Task<T> GetOrderAsync(int id);
        Task<T> CreateOrderAsync(T model);
        Task<int> DeleteOrderAsync(int id);
        Task<int> RemoveOrderItem(int orderID, int orderItemID);
        Task<int> AddOrderItem(OrderItemModel orderItem);
        Task<int> UpdateOrderStatus(int orderID, int statusID);

    }
}
