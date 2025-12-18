using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.NotFound
{
    public class BasketNotFoundException(string Id):NotFoundException($"Basket with id:{Id} not found")
    {
    }
}
