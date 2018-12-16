using Abp.Domain.Repositories;
using CCN.DashboardCustom.UserModule.POCOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.UserModule.Repositorys
{
    public interface IEmployeesRepository : IRepositoryBase<Employees, Guid>
    {
    }
}
