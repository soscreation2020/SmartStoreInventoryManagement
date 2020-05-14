using SmartStoreInventoryManagement.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Services
{
    /// <summary>
    /// Generic Service thats shields the Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IService<TEntity> //: IDisposable where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        int Total(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Guid id);
        void Delete(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool track = false);
        List<TEntity> GetAll(bool track = false);
        TEntity GetById(Guid id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, bool track = false);
        ParallelQuery<TEntity> GetPagedRecords(string procedure, params object[] @params);
        TEntity GetIncluding(Expression<Func<TEntity, bool>> predicate, bool track = false, params Expression<Func<TEntity, object>>[] properties);
        List<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties);
    }
}
