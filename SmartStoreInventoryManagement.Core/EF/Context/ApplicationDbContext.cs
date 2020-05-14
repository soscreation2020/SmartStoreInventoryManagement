using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartStoreInventoryManagement.Core.EF.Context
{
    public class ApplicationDbContext : IdentityDbContext<MyAppUser,
        MyAppRole, Guid, MyAppUserClaim,
        MyAppUserRole, MyAppUserLogin,
        MyAppRoleClaim, MyAppUserToken>, IDbContext
    {

        private IDbTransaction _transaction;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        void IDbContext.BeginTransaction()
        {
            if (Database.CurrentTransaction is null && _transaction is null)
            {

                ChangeTracker.AutoDetectChangesEnabled = false;

                _transaction = (IDbTransaction)Database.BeginTransaction();
            }
        }

        IDataReader IDbContext.CommandToReader(string Sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        int IDbContext.Commit()
        {
            var result = SaveChanges();

            _transaction.Commit();

            ChangeTracker.DetectChanges();

            return result;
        }

        IEnumerable<dynamic> IDbContext.DynamicListFromSql(string Sql, Dictionary<string, object> Params)
        {
            throw new NotImplementedException();
        }

        int IDbContext.ExecuteSqlCommand(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        void IDbContext.Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        //int IDbContext.SaveChanges()
        //{
        //    var result = SaveChanges();

        //    //_transaction.Commit();

        //    //ChangeTracker.DetectChanges();

        //    return result;
        //}

        DbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        IEnumerable<T> IDbContext.SqlQuery<T>(string sql, params object[] parameters)       {
            return  Database.ExecuteSqlToObject<T>(sql, parameters).Result;
        }



        /// </summary>
        public class AppDbContextMigrationFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public static readonly IConfigurationRoot ConfigBuilder = new ConfigurationBuilder()
                     .SetBasePath(AppContext.BaseDirectory)
                     .AddJsonFile("appsettings.json", false, true)
                     .AddJsonFile("appsettings.Development.json", false, true).Build();


            public ApplicationDbContext CreateDbContext(string[] args)
            {
                return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                                       .UseSqlServer(ConfigBuilder.GetConnectionString("Default"))
                                       .Options);
            }
        }
    }
}
