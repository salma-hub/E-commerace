using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.BadRequest
{
    internal class CreateOrderBadRequestException(): BadRequestException("Create order bad request.")
    {
    }
}
