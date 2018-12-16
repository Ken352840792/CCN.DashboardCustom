using Abp.Application.Services;

namespace CCN.DashboardCustom
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class DashboardCustomAppServiceBase : ApplicationService
    {
        protected DashboardCustomAppServiceBase()
        {
            LocalizationSourceName = DashboardCustomConsts.LocalizationSourceName;
        }
    }
}