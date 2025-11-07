using E_commerace.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IRepoestories<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>;
    }
}
