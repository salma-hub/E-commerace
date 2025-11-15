using E_commerace.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerace.Domain.Contracts
{
    public interface IRepoestories<TEntity,TKey> where TEntity : Entity<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task <TEntity> GetByIdAsync(TKey id);
        Task<TEntity> GetAsync(IBaseSpecification<TEntity> specification);
        Task <IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(IBaseSpecification<TEntity> specification);
    }
}
