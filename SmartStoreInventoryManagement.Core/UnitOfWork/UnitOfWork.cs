using SmartStoreInventoryManagement.Core.EF.Context;
using SmartStoreInventoryManagement.Core.Reposory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;
        //public bool HasTransaction =>_context.HasTransaction;

        public void BeginTransaction()
        {
            _context.SaveChanges();
        }

        public UnitOfWork(IDbContext ctxt)
        {
            _context = ctxt;
        }
        public int Commit()
        {
            return _context.Commit();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(Repository<>);

            if (!_repositories.Contains(type))
                _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IRepository<TEntity>)_repositories[type];
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed && disposing)
        //    {
        //        _context.Dispose();

        //        if (_repositories != null)
        //        {
        //            foreach (IDisposable repository in _repositories.Values)
        //                repository.Dispose();// dispose all repositries
        //        }
        //    }
        //    _disposed = true;
        //}
    }
}
