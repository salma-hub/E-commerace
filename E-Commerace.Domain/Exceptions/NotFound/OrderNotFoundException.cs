using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.NotFound
{
    public class OrderNotFoundException(Guid Id): NotFoundException($"order with Id {Id} was not found ")
    {
    }
}
