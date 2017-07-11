using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace News.ViewModel
{
    public class HomeViewModel : RenderModel
    {
        //public HomeViewModel(IPublishedContent content, CultureInfo culture) : base(content, culture)
        //{

        //}

        public HomeViewModel(IPublishedContent content) : base(content)
        {
            NewsTitle = content.GetPropertyValue<string>("NewsTitle");
            NewsContent = content.GetPropertyValue<string>("NewsContent");
            NewsImage = content.GetPropertyValue<byte[]>("NewsImage");
        }
        //the other properties need to pass to the view
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public byte[] NewsImage { get; set; }
    }
}