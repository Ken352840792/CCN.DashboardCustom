using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace CCN.DashboardCustom
{
    [DependsOn(typeof(AbpAutoMapperModule),typeof(CommonModule))]
    public class DashboardCustomCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
