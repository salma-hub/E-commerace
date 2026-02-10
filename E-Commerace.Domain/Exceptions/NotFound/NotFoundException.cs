using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.NotFound
{
    public abstract class NotFoundException(string message) : System.Exception(message)
    {

    }
}
