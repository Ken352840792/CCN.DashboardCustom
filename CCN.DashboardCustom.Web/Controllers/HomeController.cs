using System.Web.Mvc;

namespace CCN.DashboardCustom.Web.Controllers
{
    public class HomeController : DashboardCustomControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}