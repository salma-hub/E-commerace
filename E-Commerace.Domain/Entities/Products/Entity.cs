using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Domain.Entities.Products
{
    public abstract class Entity<T>
    {
        T Id {get;  set;}
    }
}
