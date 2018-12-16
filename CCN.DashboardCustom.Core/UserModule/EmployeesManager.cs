using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CCN.DashboardCustom.UserModule;
using CCN.DashboardCustom.UserModule.POCOModel;
using CCN.DashboardCustom.UserModule.Repositorys;

namespace CCN.DashboardCustom.UserModule
{
    public class EmployeesManager : DomainBase, IEmployeesManager
    {
        public IEmployeesRepository _employeesRepository { get; set; }
        public EmployeesManager(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        /// <summary>
        /// 添加员工对象
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public bool AddOrUpdateEmployees(Employees employees)
        {
            //检查上级是否存在
            if (Guid.Empty != employees.ParentId)
            {
                _employeesRepository.Get((Guid)employees.ParentId);
            }
            //something
            if (_employeesRepository.InsertOrUpdate(employees) != null)
            {
                return true;
            }
            return false;
        }
    }
}
