using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using AutoMapper;
using CCN.DashboardCustom.UserModule.Dto;
using CCN.DashboardCustom.UserModule.POCOModel;
using CCN.DashboardCustom.UserModule.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCN.DashboardCustom.UserModule.UseCase
{
    public class EmployeesService : DashboardCustomAppServiceBase, IEmployeesService
    {
        /// <summary>
        /// 公用仓储层调用
        /// </summary>
        private readonly IRepository<Employees, Guid> _employeesComRepository;
        /// <summary>
        /// 核心领域层调用
        /// </summary>
        private readonly IEmployeesManager _employeesManager;
        /// <summary>
        /// 自建仓储层调用
        /// </summary>
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(
           IRepository<Employees, Guid> employeesComRepository,
           IEmployeesManager employeesManager,
           IEmployeesRepository employeesRepository
           )
        {
            _employeesComRepository = employeesComRepository;
            _employeesManager = employeesManager;
            _employeesRepository = employeesRepository;
        }

        public void BulkInsert(List<In_Employees> in_Employees)
        {
            _employeesRepository.BulkInsert(in_Employees.MapTo<IList<Employees>>());
        }

        public bool CreateEmployees(In_Employees in_Employees)
        {
            return _employeesManager.AddOrUpdateEmployees(in_Employees.MapTo<Employees>());
        }

        public PagedResultDto<Out_Employees> GetPageAllList(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto)
        {
            return new PagedResultDto<Out_Employees>()
            {
                TotalCount = _employeesComRepository.Count(),
                Items = _employeesComRepository.GetAll().ReflectionOrderBy("CreationTime").Skip(pagedAndSortedResultRequestDto.SkipCount).Take(pagedAndSortedResultRequestDto.MaxResultCount).ToList().MapTo<IReadOnlyList<Out_Employees>>()
            };

        }
    }
}
