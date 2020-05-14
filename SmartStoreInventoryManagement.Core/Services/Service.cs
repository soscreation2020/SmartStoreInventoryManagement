using SmartStoreInventoryManagement.Core.EF;
using SmartStoreInventoryManagement.Core.Reposory;
using SmartStoreInventoryManagement.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public IUnitOfWork UnitOfWork { get; private set; }
        protected ValidationResult resultse;
        protected List<ValidationResult> results = new List<ValidationResult>();
       //= new List<ValidationResult>();

        private bool _disposed;
        public Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<TEntity>();
        }
        int IService<TEntity>.Total(Expression<Func<TEntity, bool>> predicate)
        {
            return Count(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Create(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _repository.Create(entities);
        }

        public virtual void Delete(TEntity entity)
        {

            _repository.Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate, bool track)
        {
            return _repository.Get(predicate, track);
        }

        public virtual TEntity Find(Guid id)
        {
            return _repository.Get(id);
        }
        public virtual List<TEntity> All(Expression<Func<TEntity, bool>> predicate, bool track)
        {

            return
                _repository.Fetch(predicate, track).ToList();
        }

        public virtual List<TEntity> All(bool track)
        {
            return
                _repository.Fetch(track).ToList();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {

            return _repository.Count(predicate);
        }

        public virtual TEntity GetIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties)
        {
            return _repository.GetAllIncluding(predicate, track, properties).SingleOrDefault();
        }

        public virtual List<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties)
        {
            return _repository.GetAllIncluding(predicate, track, properties).ToList();
        }


        void IService<TEntity>.Add(TEntity entity)
        {
            Add(entity);
        }

        void IService<TEntity>.Add(IEnumerable<TEntity> entities)
        {
            Add(entities);
        }

        void IService<TEntity>.Delete(TEntity entity)
        {
            Delete(entity);
        }

        List<TEntity> IService<TEntity>.GetAll(Expression<Func<TEntity, bool>> predicate, bool track)
        {
            return All(predicate, track);
        }
        List<TEntity> IService<TEntity>.GetAll(bool track)
        {
            return All(track);
        }
        TEntity IService<TEntity>.GetById(Guid id)
        {
            return Find(id);
        }

        TEntity IService<TEntity>.Get(Expression<Func<TEntity, bool>> predicate, bool track)
        {
            return Find(predicate, track);
        }

        void IService<TEntity>.Update(TEntity entity)
        {
            Update(entity);
        }
        public async Task<Int32> AddAsync(TEntity entity)
        {
            _repository.Insert(entity);
            return await UnitOfWork.SaveChangesAsync();
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Int32> DeleteAsync(TEntity entity)
        {
            _repository.Delete(entity);
            return await UnitOfWork.SaveChangesAsync();
        }
        public async Task<Int32> UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            return await UnitOfWork.SaveChangesAsync();
        }
        public virtual ParallelQuery<TEntity> GetPagedRecords(string procedureName, params object[] extraQueries)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Exec {0} ", procedureName));

            var parameters = new List<object> { };

            foreach (var item in extraQueries)
                parameters.Add(item);

            var counter = parameters.Count();
            for (int i = 0; i < counter; i++)
            {
                sb.Append("@p" + i);
                if (i < counter - 1)
                    sb.Append(", ");
            }

            return UnitOfWork.Repository<TEntity>().SqlQuery(sb.ToString(), parameters.ToArray())
                .AsParallel();
        }

        ParallelQuery<TEntity> IService<TEntity>.GetPagedRecords(string procedure, params object[] @params)
        {
            return GetPagedRecords(procedure, @params);
        }
        public async Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Expression<Func<TEntity, Guid>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _repository.GetAllAsync(pageIndex, pageSize, keySelector, predicate, orderBy, includeProperties);
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
        //        UnitOfWork.Dispose();
        //    }
        //    _disposed = true;
        //}

        TEntity IService<TEntity>.GetIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties)
        {
            return GetIncluding(predicate, track, properties);
        }

        List<TEntity> IService<TEntity>.GetAllIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties)
        {
            return GetAllIncluding(predicate, track, properties);
        }
    }
}
