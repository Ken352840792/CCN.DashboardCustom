using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using CCN.DashboardCustom.EntityFramework;

namespace CCN.DashboardCustom
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(DashboardCustomCoreModule))]
    public class DashboardCustomDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<DBContext>(null);
        }
    }
}
