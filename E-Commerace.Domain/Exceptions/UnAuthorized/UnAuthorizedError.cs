using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Exceptions.UnAuthorized
{
    public class UnAuthorizedError():System.Exception("You are not authorized to perform this action.")
    {
    }
}
