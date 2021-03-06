﻿using Microsoft.EntityFrameworkCore;
using SmartStoreInventoryManagement.Core.EF;
using SmartStoreInventoryManagement.Core.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.Reposory
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
       // private readonly ApplicationDbContext _applicationContext;
        private readonly DbSet<TEntity> Entities;
        private readonly IDbContext _context;
        public Repository(IDbContext context)
        {
            //_applicationContext = applicationContext;
            _context = context;
            Entities = _context.Set<TEntity>();

        }

        //protected virtual DbSet<TEntity> Entitiess
        //{
        //    get { return _applicationContext.Set<TEntity>(); }
        //}
        //public void Adds()
        //{
        //    _applicationContext.SaveChanges();
        //}
        public void Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Add(entity);
            _context.SaveChanges();

        }
        public virtual void Create(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");

            foreach (var entity in entities)
                Entities.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new NotImplementedException("entity");
            Entities.Remove(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(IEnumerable<TEntity> entities)
        {

            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                Entities.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity GetById(int Id)
        {
            return Entities.Find(Id);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            //Entities.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Fetch(predicate)
                     .AsNoTracking()
                          .Count();
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate, bool track = false)
        {
            return
                track ? Fetch(predicate).SingleOrDefault() :
                    Fetch(predicate).AsNoTracking()
                                    .SingleOrDefault();
        }
        public virtual TEntity Get(object id)
        {
            return Entities.Find(id);
        }
        public virtual IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public virtual IQueryable<TEntity> Fetch()
        {
            return Entities;
        }


        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }


        public virtual IEnumerable<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, bool track, params Expression<Func<TEntity, object>>[] properties)
        {
            var entities = IncludeProperties(properties);

            return
                track ? entities.Where(predicate) :
                    entities.Where(predicate).AsNoTracking();
        }

        public IQueryable<TEntity> IncludeProperties(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> entities = Entities;
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

        public IEnumerable<TEntity> Fetch(bool track)
        {
            return
                track ?
                Fetch()
                      .ToList()
                       .AsReadOnly()
               : Fetch()
                        .AsNoTracking()
                         .ToList()
                          .AsReadOnly();
        }
        IEnumerable<TEntity> IRepository<TEntity>.Fetch(Expression<Func<TEntity, bool>> predicate, bool track)
        {
            return
                track ?
                Fetch(predicate)
                                .ToList()
                                     .AsReadOnly()
               : Fetch(predicate)
                              .AsNoTracking()
                                  .ToList()
                                     .AsReadOnly();
        }
        public IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate, bool track = false)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<TEntity> SqlQuery(string sql, params object[] parameters)
        //{
        //    try {
        //        return SqlQuery(sql, parameters);
        //    } catch {


        //    }

        //}
        public virtual IEnumerable<TEntity> SqlQuery(string sql, params object[] parameters)
        {
            return _context.SqlQuery<TEntity>(sql, parameters);
        }
        IEnumerable<TEntity> IRepository<TEntity>.SqlQuery(string sql, params object[] parameters)
        {
            return SqlQuery(sql, parameters);
        }
        public void Insert(TEntity entity)
        {
            //throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Expression<Func<TEntity, Guid>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
