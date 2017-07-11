using News.ViewModel;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace News.Controller
{
    public class HomeController : SurfaceController
    {
        // GET: Home
        public ActionResult Index(RenderModel model)
        {
            var homeViewModel = new HomeViewModel(CurrentPage);
            //return View(model);
            //return CurrentTemplate(homeViewModel);
            return View(model);
        }

    }
}