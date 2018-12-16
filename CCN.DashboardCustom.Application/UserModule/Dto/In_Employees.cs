using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CCN.DashboardCustom.UserModule.POCOModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.UserModule.Dto
{
    [AutoMapTo(typeof(Employees))]
    /// <summary>
    ///员工数据传入实体
    /// </summary>
    public class In_Employees
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid? Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "长度不能超过10个字符")]
        /// <summary>
        /// 名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
