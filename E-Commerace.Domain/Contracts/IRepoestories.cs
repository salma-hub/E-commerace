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
        Task <TEntity> GetById(TKey id);
        Task <IEnumerable<TEntity>> GetAll();
    }
}
