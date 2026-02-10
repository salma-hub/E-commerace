using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Shared
{
    public record  PaginateResult<TResult>(int PageIndex, int Count,int TotalCount,IEnumerable<TResult> Data)
    {


    }
}
