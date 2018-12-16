using System.Linq;
using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web.Api;
using Abp.WebApi;
using Swashbuckle.Application;

namespace CCN.DashboardCustom
{
    [DependsOn(typeof(AbpWebApiModule), typeof(DashboardCustomApplicationModule),typeof(AbpWebApiSwaggerToolModule))]
    public class DashboardCustomWebApiModule : AbpModule
    {
        public override void PreInitialize()
        {
            //ABP只对POST,PUT,PATCH,DELETE动词实现了反伪造（Anti-Forgery）保护API,这里将之禁用 CSRF
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
            base.PreInitialize();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(Assembly.GetAssembly(typeof(DashboardCustomApplicationModule)), "app")
                .WithConventionalVerbs()
                .Build();
            //ConfigureSwaggerUi();
        }
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SwaggerIntegrationDemo.WebApi");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {
                    c.InjectJavaScript(Assembly.GetAssembly(typeof(DashboardCustomApplicationModule)), "CCN.DashboardCustom.WebApi.SwaggerUi.Swagger-Custom.js");
                });
        }
    }
}
