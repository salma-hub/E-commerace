
using E_commerace.Domain.Entities;
using E_commerace.Persistence.Context;
using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
namespace E_commerace.Persistence.Repoestories
{
    public class UnitOfWork(StoreDbContext storeDbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> repositories = new();
        public IRepoestories<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
          
            var typeName=typeof(TEntity).Name;
            if (repositories.TryGetValue(typeName, out object? value))
            {
                return (value as IRepoestories<TEntity, TKey>);
    }
            var repositoryInstance = new Repository<TEntity, TKey>(storeDbContext);
            repositories.Add(typeName, repositoryInstance);
            return repositoryInstance;
        }

        public async Task<int> SaveChangesAsync()
            => await storeDbContext.SaveChangesAsync();
    }
}
