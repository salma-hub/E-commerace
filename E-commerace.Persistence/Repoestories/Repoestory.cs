using E_commerace.Domain.Entities.Products;
using E_commerace.Persistence.Context;
using E_Commerace.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Persistence.Repoestories
{
    public class Repoestory<TEntity, TKey>(StoreDbContext storeDbContext) :IRepoestories <TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly DbSet<TEntity> _dbSet = storeDbContext.Set<TEntity>();
        public void Add(TEntity entity)
       =>storeDbContext.Set<TEntity>().Add(entity);

        public async Task<int> CountAsync(IBaseSpecification<TEntity> specification)
        => await _dbSet.ApplySepcification(specification).CountAsync();

        public void Delete(TEntity entity)
       => storeDbContext.Set<TEntity>().Remove(entity);
        public async Task<IEnumerable<TEntity>> GetAll()
       =>await storeDbContext.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAll(IBaseSpecification<TEntity> specification) =>
            await _dbSet.ApplySepcification(specification).ToListAsync();

        public async Task<TEntity> GetAsync(IBaseSpecification<TEntity> specification)
        
          => await _dbSet.ApplySepcification(specification).FirstOrDefaultAsync();
        

        public async Task<TEntity> GetByIdAsync(TKey id)
            => await storeDbContext.Set<TEntity>().FindAsync(id);
        public void Update(TEntity entity)
        => storeDbContext.Set<TEntity>().Update(entity);
    }
}
