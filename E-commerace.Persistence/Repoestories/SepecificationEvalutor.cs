using E_commerace.Persistence.Context;
using E_Commerace.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Persistence.Repoestories
{
    public static class SepecificationEvalutor
    {
        public static IQueryable<T> ApplySepcification<T>(this IQueryable<T> inputQuery,
           IBaseSpecification<T> spec) where T : class
        {
            var query = inputQuery;
            // Apply criteria
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            // Apply includes
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            //Apply OrderBy
            if(spec.OrderBy!=null)
            query = query.OrderBy(spec.OrderBy);
            if(spec.OrderByDesc!=null)
                query = query.OrderByDescending(spec.OrderByDesc);
            if (spec.IsPaginated)
            
                query = query.Skip(spec.Skip).Take(spec.Take);
            
            return query;
        }
    }
}
