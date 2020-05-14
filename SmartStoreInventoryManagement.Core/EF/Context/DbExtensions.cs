﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.EF.Context
{
    public static class DbExtensions
    {
        public static async Task<IEnumerable<T>> ExecuteSqlToObject<T>(this DatabaseFacade database, string sql, params object[] parameters)
        {
            var response = new List<T>();
            var properties = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            var conn = database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }

            var command = conn.CreateCommand();

            command.CommandText = sql;

            if (null != parameters
           && parameters.Length > 0)
            {
                var dbParameters = new DbParameter[parameters.Length];

                if (parameters.All(p => p is DbParameter))
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        dbParameters[i] = (DbParameter)parameters[i];
                    }
                }
                else if (!parameters.Any(p => p is DbParameter))
                {
                    var sb = new StringBuilder(sql).Append(" ");

                    var length = parameters.Length;
                    for (int i = 0; i < length; i++)
                    {
                        sb.Append("@p" + i);
                        if (i < length - 1)
                            sb.Append(", ");

                        dbParameters[i] = command.CreateParameter();
                        dbParameters[i].ParameterName = string.Format("p{0}", i);
                        dbParameters[i].Value = parameters[i] ?? DBNull.Value;
                    }

                    command.CommandText = sb.ToString();
                }
                else
                {
                    throw new InvalidOperationException("couldn't mix dbparameter and other objects");
                }

                command.Parameters.AddRange(dbParameters);
            }

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();

                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var type = reader.GetFieldType(i);

                        var val = reader.GetValue(i);
                        row.Add(reader.GetName(i), val == DBNull.Value ? null : val);
                    }

                    var instance = Activator.CreateInstance<T>();

                    foreach (var column in row.Keys)
                    {
                        foreach (var property in properties)
                        {
                            if (column == property.Name)
                                property.SetValue(instance, row[column]);
                        }
                    }

                    response.Add(instance);
                }
            }

            return response;
        }
    }
}
