using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CCN.DashboardCustom
{
   public class CommonModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            base.Initialize();
        }
    }
}
