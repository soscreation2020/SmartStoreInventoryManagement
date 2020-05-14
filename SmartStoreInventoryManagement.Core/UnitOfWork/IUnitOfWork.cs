using SmartStoreInventoryManagement.Core.Reposory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.UnitOfWork
{
    public interface IUnitOfWork //: IDisposable
    {
        int SaveChanges();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> SaveChangesAsync();
        //bool HasTransaction { get; }
    }
}
