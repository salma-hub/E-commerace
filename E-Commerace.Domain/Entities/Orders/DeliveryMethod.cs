using E_commerace.Domain.Entities;

namespace E_Commerace.Domain.Entities.Orders
{
    //represents delivery methods available for orders
    public class DeliveryMethod: BaseEntity<int>
    { 
       

        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Price { get; set; }
    }
}