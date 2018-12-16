using Abp.Domain.Services;
using CCN.DashboardCustom.UserModule.POCOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.UserModule
{
    public interface IEmployeesManager: IDomainService
    {
        bool AddOrUpdateEmployees(Employees employees);
    }
}
