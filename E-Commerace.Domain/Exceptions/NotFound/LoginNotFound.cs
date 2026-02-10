using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.NotFound
{
    public class LoginNotFound(string email):NotFoundException($"the email ${email}was not found ")
    {
    }
}
