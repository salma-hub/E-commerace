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

        public Expression<Func<T, object>> OrderBy  {get; private set;}

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Skip  { get; private set; }

        public int Take  { get; private set; }

        public bool IsPaginated  { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> expression) => OrderBy = expression;




        protected void AddOrderByDesc(Expression<Func<T, object>> expression) => OrderByDesc = expression;
        protected void ApplyPagination(int pageSize,int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = pageSize * (pageIndex - 1);


        }

    }
}
