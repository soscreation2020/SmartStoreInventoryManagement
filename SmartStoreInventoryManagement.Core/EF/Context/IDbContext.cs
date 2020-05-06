using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartStoreInventoryManagement.Core.EF.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void BeginTransaction();
        int Commit();
        void Rollback();
        IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, params object[] parameters);

        IEnumerable<dynamic> DynamicListFromSql(string Sql, Dictionary<string, object> Params);
        IDataReader CommandToReader(string Sql, params object[] parameters);
    }
}
