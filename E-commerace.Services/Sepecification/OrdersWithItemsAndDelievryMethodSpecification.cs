using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Orders;

namespace E_commerace.Services.Sepecification
{
    public class OrdersWithItemsAndDelievryMethodSpecification :BaseSecficiation<Order>
    {
        public OrdersWithItemsAndDelievryMethodSpecification(string userEmail)
            :base(o=>o.UserEmail.ToLower() == userEmail.ToLower())
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
           
           
            AddOrderByDesc(o => o.OrderDate);
        }
        public OrdersWithItemsAndDelievryMethodSpecification(Guid Id ,string userEmail)
          : base(o => o.UserEmail.ToLower() == userEmail.ToLower() &&o.Id==Id)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }

    }
}