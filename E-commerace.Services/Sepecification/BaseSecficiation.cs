using E_Commerace.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Sepecification
{
    public abstract class BaseSecficiation<T>:IBaseSpecification<T> where T : class
    {
        public BaseSecficiation(Expression<Func<T, bool>>criteria)
        {
          Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; private set; }
        public ICollection<Expression<Func<T, object>>> Includes { get; private set; }=new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

    }
}
