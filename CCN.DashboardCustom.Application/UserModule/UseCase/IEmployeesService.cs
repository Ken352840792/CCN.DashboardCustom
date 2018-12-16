using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CCN.DashboardCustom.UserModule.Dto;
using System.Collections.Generic;

namespace CCN.DashboardCustom.UserModule.UseCase
{
    public interface IEmployeesService : IApplicationService
    {
        /// <summary>
        /// 添加或修改员工
        /// </summary>
        /// <param name="in_Employees">员工数据</param>
        /// <returns>成功失败</returns>
        bool CreateEmployees(In_Employees in_Employees);
        PagedResultDto<Out_Employees> GetPageAllList(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto);
        void BulkInsert(List<In_Employees> in_Employees);

    }
}
