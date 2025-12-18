using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.BadRequest
{
    public class CreateOrUpdateBasketBadRequestException(): BadRequestException("Create or update basket bad request exception.")
    {
    }
}
