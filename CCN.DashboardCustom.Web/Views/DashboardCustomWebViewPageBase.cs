using Abp.Web.Mvc.Views;

namespace CCN.DashboardCustom.Web.Views
{
    public abstract class DashboardCustomWebViewPageBase : DashboardCustomWebViewPageBase<dynamic>
    {

    }

    public abstract class DashboardCustomWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected DashboardCustomWebViewPageBase()
        {
            LocalizationSourceName = DashboardCustomConsts.LocalizationSourceName;
        }
    }
}