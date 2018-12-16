using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.UserModule.POCOModel
{
    [Table("sy_employees")]
    /// <summary>
    /// 员工实体
    /// </summary>
    public partial class Employees: EntityBase
    {
       
        public   string UserName { get; set; }
        public   string Pwd { get; set; }
        public   string Email { get; set; }
        public   string Address { get; set; }
        public   string QQ { get; set; }
        public   Guid? ParentId { get; set; }
    }
}
