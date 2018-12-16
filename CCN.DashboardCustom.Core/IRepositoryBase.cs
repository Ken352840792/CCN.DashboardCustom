using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom
{
    public interface IRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entity"></param>
        void BulkInsert(IList<TEntity> entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param Name="list"></param>
        void BulkDelete(IList<TEntity> list);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param Name="list"></param>
        void BulkUpdate(IList<TEntity> list);

        #region 纯SQL操作 尽量不要使用
        /// <summary>
        /// 执行SQL语句，返回影响的行数
        /// </summary>
        /// <param Name="SqlStr"></param>
        /// <param Name="parameters"></param>
        /// <returns></returns>
        int ExecuteSql(string SqlStr, List<SqlParameter> parameters);

        /// <summary>
        /// 根据Sql语句查询单个对象
        /// </summary>
        /// <typeparam Name="T"></typeparam>
        /// <param Name="SqlStr"></param>
        /// <param Name="parameters"></param>
        /// <returns></returns>
        T FirstOrDefault<T>(string SqlStr, List<SqlParameter> parameters);

        /// <summary>
        /// 查询数据条数
        /// </summary>
        /// <param Name="SqlStr"></param>
        /// <param Name="parameters"></param>
        /// <returns></returns>
        int SelectCount(string SqlStr, List<SqlParameter> parameters);

        /// <summary>
        /// 执行查询语句，返回List集合
        /// </summary>
        /// <param Name="SqlStr"></param>
        /// <param Name="parameters"></param>
        /// <returns></returns>
        List<T> Query<T>(string SqlStr, List<SqlParameter> parameters);
        #endregion
       

    }
}
