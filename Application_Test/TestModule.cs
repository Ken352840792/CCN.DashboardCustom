using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.Modules;
using Abp.TestBase;
using Castle.Facilities.Logging;
using CCN.DashboardCustom;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application_Test
{
    [DependsOn(
  typeof(AbpTestBaseModule),
  typeof(DashboardCustomApplicationModule),
        typeof(DashboardCustomDataModule))]
    public class TestModule : AbpModule
    {
        public override void PreInitialize()
        {
            var _iocManager = IocManager.Resolve<IIocManager>();
            _iocManager.IocContainer.AddFacility<LoggingFacility>(
              f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );
            base.PreInitialize();
        }
    }
}
