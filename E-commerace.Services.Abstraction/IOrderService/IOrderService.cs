using E_commerace.Shared.Dtos.Orders;


namespace E_commerace.Services.Abstraction.IOrderService
{
    public interface IOrderService
    { 
        Task<OrderResponse?> CreateOrderAsync(OrderRequest orderRequest, string UserEmail);

        Task<IEnumerable<DelieveryMethodResponse>> GetAllDelieveryMethod();
        Task<OrderResponse?> GetOrdersByIdForUserAsync(Guid orderId, string UserEmail);
        Task<IEnumerable<OrderResponse>> GetOrdersForUserAsync(string UserEmail);

    }
}
