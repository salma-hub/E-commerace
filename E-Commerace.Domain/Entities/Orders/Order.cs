using E_commerace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Entities.Orders
{
    public class Order: BaseEntity<Guid>
    {
        public Order()
        {
        }   
        public Order(string userEmail, Address shipToAddress, ICollection<OrderItem> orderItems, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            UserEmail = userEmail;
            ShipToAddress = shipToAddress;
            OrderItems = orderItems;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public OrderStatus Status { get; set; }= OrderStatus.Pending;
        public Address ShipToAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }//navigation property
        public DeliveryMethod DeliveryMethod { get; set; }//navigation property
        public int DeliveryMethodId { get; set; }//foreign key
        public decimal Subtotal { get; set; }//price * quantity
     //   public decimal Total { get; set; }   //subtotal + delivery fee
        public decimal GetTotal()
        {
            return Subtotal+DeliveryMethod.Price;
        }
         

    }
}
