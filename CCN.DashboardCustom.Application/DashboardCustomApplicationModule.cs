using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace CCN.DashboardCustom
{
    [DependsOn(  typeof(DashboardCustomCoreModule), typeof(AbpAutoMapperModule),typeof(CommonModule))]
    public class DashboardCustomApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            // 依赖注入
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
