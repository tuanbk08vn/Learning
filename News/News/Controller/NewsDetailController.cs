//using News.ViewModel;
//using System.Web.Mvc;
//using Umbraco.Web.Mvc;

//namespace News.Controller
//{
//    public class NewsDetailController : RenderMvcController
//    {
//        // GET: NewsDetail

//        public ActionResult Index(PostNewsViewModel model)
//        {
//            var news = new NewsDetailViewModel();
//            news.NewsTitle = model.NewsTitle;
//            news.NewsContent = model.NewsContent;
//            news.NewsImage = model.NewsImage;
//            //var newsDetail = new NewsDetailViewModel(CurrentPage);
//            return PartialView("_NewsDetailPartial", news);
//        }

//        //public ActionResult ReadNews(PostNewsViewModel model)
//        //{
//        //    return View("NewDetail", model);
//        //}

//        //[HttpPost]
//        //public ActionResult BackToHome()
//        //{
//        //    return this.Redirect("/home");
//        //}
//    }
//}