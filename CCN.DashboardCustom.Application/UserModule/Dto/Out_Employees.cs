using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CCN.DashboardCustom.UserModule.POCOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.UserModule.Dto
{
    [AutoMapTo(typeof(Employees))]
    /// <summary>
    /// 员工数据输出实体
    /// </summary>
    public class Out_Employees: EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string QQ { get; set; }
        public Guid ParentId { get; set; }
    }
}
