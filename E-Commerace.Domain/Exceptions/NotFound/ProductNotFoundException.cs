using E_Commerace.Domain.Exceptions.NotFound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exception.NotFound
{
    public class ProductNotFoundException(int Id): NotFoundException($"Product with Id {Id} was not found")
    {
    }
}
