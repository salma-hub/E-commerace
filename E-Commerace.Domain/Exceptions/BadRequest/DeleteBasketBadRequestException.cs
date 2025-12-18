using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.BadRequest
{
    public class DeleteBasketBadRequestException(): BadRequestException("Delete basket bad request exception.")
    {
    }
}
