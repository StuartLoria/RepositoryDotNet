using Microsoft.EntityFrameworkCore;
using RepositoryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepositoryEF.Implementations
{
    /// <summary>
    /// EF implementation of a Generic Repository
    /// </summary>
    /// <typeparam name="TEntity">Concrete Entity Type</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        private DbSet<TEntity> GetModelFromContext()
        {
            return Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            GetModelFromContext().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            GetModelFromContext().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> foundCollection = GetModelFromContext().Where(predicate);
            return foundCollection;
        }

        public TEntity Get(int id)
        {
            TEntity foundEntity = GetModelFromContext().Find(id);
            return foundEntity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> entityCollection = GetModelFromContext().ToList();
            return entityCollection;
        }

        public void Remove(TEntity entity)
        {
            GetModelFromContext().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            GetModelFromContext().RemoveRange(entities);
        }
    }
}
