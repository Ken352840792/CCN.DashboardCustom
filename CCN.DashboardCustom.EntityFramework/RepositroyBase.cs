using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom
{
    public class RepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DBContext, TEntity, TPrimaryKey>
         , IRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public RepositoryBase(IDbContextProvider<DBContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public void BulkInsert(IList<TEntity> entity)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;
            Context.BulkInsert(entity);
            Context.Configuration.AutoDetectChangesEnabled = true;
        }

        public void BulkDelete(IList<TEntity> entity)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;
            Context.BulkDelete(entity);
            Context.Configuration.AutoDetectChangesEnabled = true;
        }
        public void BulkUpdate(IList<TEntity> entity)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;
            Context.BulkUpdate(entity);
            Context.Configuration.AutoDetectChangesEnabled = true;
        }
        
        #region 纯SQL操作
        public int ExecuteSql(string SqlStr, List<SqlParameter> parameters)
        {
            return Context.Database.ExecuteSqlCommand(SqlStr, parameters.ToArray());
        }

        public T FirstOrDefault<T>(string SqlStr, List<SqlParameter> parameters)
        {
            return Context.Database.SqlQuery<T>(SqlStr, parameters.ToArray()).FirstOrDefault();
        }

        public int SelectCount(string SqlStr, List<SqlParameter> parameters)
        {
            return Context.Database.SqlQuery<int>(SqlStr, parameters.ToArray()).FirstOrDefault();
        }

        public List<T> Query<T>(string SqlStr, List<SqlParameter> parameters)
        {
            return Context.Database.SqlQuery<T>(SqlStr, parameters.ToArray()).ToList();
        }
        #endregion
    }
}
