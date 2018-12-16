using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
 
using CCN.DashboardCustom.UserModule.POCOModel;
using CCN.DashboardCustom.UserModule.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.Repositories.UserModule
{
    public class EmployeesRepository : RepositoryBase<Employees,Guid>, IEmployeesRepository
    {
        public EmployeesRepository(IDbContextProvider<DBContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
    }
}
