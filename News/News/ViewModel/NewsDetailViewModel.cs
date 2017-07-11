namespace News.ViewModel
{
    public class NewsDetailViewModel
    {

        //public PostNewsViewModel(IPublishedContent content) : base(content)
        //{
        //    //NewsTitle = content.GetPropertyValue<string>("NewsTitle");
        //    //NewsContent = content.GetPropertyValue<string>("NewsContent");
        //    //NewsImage = content.GetPropertyValue<string>("NewsImage");
        //}

        //the other properties need to pass to the view
        public string NewsTitle { get; set; }

        public string NewsContent { get; set; }
        public string NewsImage { get; set; }
        //public MediaViewModel NewsPhoto { get; set; }
        //public HttpPostedFileBase file { get; set; }
    }
}