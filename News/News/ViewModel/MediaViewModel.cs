using System.Web;

namespace News.ViewModel
{
    public class MediaViewModel
    {
        public HttpPostedFileBase file { get; set; }
        public string FileNameAlias { get; set; }
        public string NameOfImage { get; set; }
        public string ParentMediaName { get; set; }
    }
}