using Abp.Web.Mvc.Controllers;

namespace CCN.DashboardCustom.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class DashboardCustomControllerBase : AbpController
    {
        protected DashboardCustomControllerBase()
        {
            LocalizationSourceName = DashboardCustomConsts.LocalizationSourceName;
        }
    }
}