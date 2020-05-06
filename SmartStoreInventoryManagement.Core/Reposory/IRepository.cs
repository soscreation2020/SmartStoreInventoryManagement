using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Reposory
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Create(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);
        int Count(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(object id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, bool track = false);
        IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Fetch();
        IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate, bool track = false);
        IEnumerable<TEntity> Fetch(bool track = false);
        IEnumerable<TEntity> SqlQuery(string sql, params object[] parameters);
        IEnumerable<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties);
        IQueryable<TEntity> IncludeProperties(params Expression<Func<TEntity, object>>[] includeProperties);

    }
}
