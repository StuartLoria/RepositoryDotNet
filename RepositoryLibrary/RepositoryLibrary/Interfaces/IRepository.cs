using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RepositoryLibrary.Interfaces
{
    /// <summary>
    /// It behaves as a collection of domain objects in memory
    /// </summary>
    /// <remarks>It encapsulates queries
    /// Repositories don't have update methods
    /// Repositories encapsulate persistance implementation details from its clients
    /// </remarks>
    /// <typeparam name="TEntity">Concrete Entity Type</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
