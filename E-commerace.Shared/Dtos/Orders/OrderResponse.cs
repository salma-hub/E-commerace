using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Shared.Dtos.Orders
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
     
        public OrderAddress ShipToAddress { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public string DeliveryMethod { get; set; }
      
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
