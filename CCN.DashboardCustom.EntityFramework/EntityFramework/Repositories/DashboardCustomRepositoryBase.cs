using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CCN.DashboardCustom.EntityFramework.Repositories
{
    public abstract class DashboardCustomRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DashboardCustomDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected DashboardCustomRepositoryBase(IDbContextProvider<DashboardCustomDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class DashboardCustomRepositoryBase<TEntity> : DashboardCustomRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected DashboardCustomRepositoryBase(IDbContextProvider<DashboardCustomDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
