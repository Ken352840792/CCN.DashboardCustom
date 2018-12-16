using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Abp.Reflection;
using CCN.DashboardCustom.UserModule.POCOModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom
{
    [AutoRepositoryTypes(typeof(IRepository<>), typeof(IRepositoryBase<,>),
          typeof(EfRepositoryBase<,>), typeof(RepositoryBase<,>), WithDefaultRepositoryInterfaces = true)]
    public class DBContext: AbpDbContext
    {
        #region IDbSet 
        public virtual IDbSet<Employees> Employees { get; set; }
        #endregion
        public DBContext()
           : base("Default")
        {

        }
        public DBContext(string nameOrConnectionString)
           : base(nameOrConnectionString)
        {
            this.Database.Log = (log) =>
            {
                this.Logger.InfoFormat("pgyer_sql:{0}", log);
            };
        }

        //This constructor is used in tests
        public DBContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public DBContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var typefinder = IocManager.Instance.Resolve<ITypeFinder>();
            //var typesToRegister = typefinder.FindAll().Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
            //    type.BaseType.GetGenericTypeDefinition() == typeof(AbsEntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            base.OnModelCreating(modelBuilder);
        }
    }
}