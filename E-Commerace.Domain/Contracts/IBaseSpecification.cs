using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Contracts
{
    public interface IBaseSpecification<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
        ICollection<Expression<Func<T, object>>> Includes { get; }
        Expression <Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
        int Skip { get; }
        int Take { get; }
        bool IsPaginated { get; }
    }
}
