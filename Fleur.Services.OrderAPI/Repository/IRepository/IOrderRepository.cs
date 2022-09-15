using Fleur.Services.OrderAPI.Models;

namespace Fleur.Services.OrderAPI.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
