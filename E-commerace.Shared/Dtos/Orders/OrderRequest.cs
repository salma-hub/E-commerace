using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Shared.Dtos.Orders
{ 
    public class OrderRequest
    {
        public string BasketId { get; set; }
        public int DelievryMethodId { get; set; }
        public OrderAddress shipToAddress { get; set; }
    }
}
