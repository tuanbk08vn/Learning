using News.ViewModel;
using System;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace News.Controller
{
    public class PostNewsController : SurfaceController
    {

        // GET: PostNews
        public ActionResult Index()
        {
            return PartialView("_PostNewsPartial", new PostNewsViewModel());
        }

        [HttpPost]
        //protected int AddImageToUmbraco(MediaViewModel media)
        //{
        //    var mediaService = Services.MediaService;
        //    var newImage = mediaService.CreateMedia(media.NameOfImage,uQuery.GetMediaByName(media.ParentMediaName).FirstOrDefault().Id, "Image",me
        //}
        public ActionResult AddNewsPost(PostNewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var news = Services.ContentService.CreateContent(model.NewsTitle, CurrentPage.Id, "PostNews");
                    var mediaServices = Services.MediaService;
                    var media = mediaServices.CreateMedia(model.NewsTitle, 1186, "Image");

                    HttpPostedFileBase image = Request.Files[0];
                    media.SetValue("umbracoFile", image);
                    mediaServices.Save(media);
                    news.SetValue("newsTitle", model.NewsTitle);
                    news.SetValue("newsContent", model.NewsContent);
                    news.SetValue("newsImage", model.NewsImage);
                    news.SetValue("newsPhoto", media.Id);
                    //var img = UpLoadImage(model);

                    Services.ContentService.Save(news);
                    TempData["Message"] = "Successfully!";
                    return this.Redirect("/home");
                }
                catch (Exception e)
                {
                    TempData["Message"] = "Unsuccessfully!";
                    return CurrentUmbracoPage();
                    throw;
                }
            }
            return RedirectToCurrentUmbracoPage();
        }

        //public ActionResult ShowDetail(PostNewsViewModel model)
        //{
        //    return View("NewsDetail", model);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpLoadImage(PostNewsViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        TempData["fail"] = true;
        //        return CurrentUmbracoPage();
        //    }

        //    //get logged in user properties for upload folder
        //    var mem = Members.GetCurrentMember();
        //    var folder = mem.GetPropertyValue("userName");

        //    //upload file to media folder
        //    if ((string)folder != string.Empty)
        //    {
        //        if (mem != null)
        //        {
        //            var ms = Services.MediaService;
        //            var childfolder = ms.GetById(1143);//1143 is upload folder in media

        //            if (childfolder.IsValid())
        //            {

        //                var foldermatch = false;
        //                var foldermatchid = -1;
        //                foreach (var memfolder in childfolder.Children().Where(x => x.ContentType.Alias == "Folder"))
        //                {
        //                    if (memfolder.Name.ToLower() == folder.ToString().ToLower())
        //                    {
        //                        foldermatch = true;
        //                        foldermatchid = memfolder.Id;
        //                        break;
        //                    }
        //                }

        //                if (foldermatch)
        //                {
        //                    //there is a members folder
        //                    var isimg = IsImage(model.file);
        //                    //var isfile = IsFile(model.Artworkfile);

        //                    if (isimg)
        //                    {
        //                        //save as image
        //                        var mediaService = Services.MediaService;
        //                        var media1 = mediaService.CreateMedia(model.file.FileName, foldermatchid, "Image");
        //                        mediaService.Save(media1);

        //                        media1.SetValue("umbracoFile", model.file);
        //                        mediaService.Save(media1);

        //                        //Update success flag (in a TempData key)
        //                        TempData["artworkUploadSuccess"] = true;

        //                    }
        //                    else
        //                    {
        //                        //mime type not supported, don't upload
        //                        TempData["artworkUploadFail"] = true;
        //                    }

        //                }
        //                else
        //                {
        //                    //there is no members folder, create one
        //                    var mediaFolder = ms.CreateMedia(folder.ToString(), 1143, "Folder");
        //                    ms.Save(mediaFolder);

        //                    //check type of file - image or file
        //                    var isimg = IsImage(model.file);
        //                    //var isfile = IsFile(model.file);

        //                    if (isimg)
        //                    {
        //                        //save as image
        //                        var mediaService = Services.MediaService;
        //                        var media = mediaService.CreateMedia(model.file.FileName, mediaFolder, "Image");
        //                        mediaService.Save(media);

        //                        media.SetValue("umbracoFile", model.file);
        //                        mediaService.Save(media);

        //                        //Update success flag (in a TempData key)
        //                        TempData["artworkUploadSuccess"] = true;
        //                    }
        //                    //else if (isfile)
        //                    //{
        //                    //    //save as file
        //                    //    var mediaService = Services.MediaService;
        //                    //    var media = mediaService.CreateMedia(model.Artworkfile.FileName, mediaFolder, "File");
        //                    //    mediaService.Save(media);

        //                    //    media.SetValue("umbracoFile", model.Artworkfile);
        //                    //    mediaService.Save(media);

        //                    //    //Update success flag (in a TempData key)
        //                    //    TempData["artworkUploadSuccess"] = true;
        //                    //}
        //                    //else
        //                    //{
        //                    //    //mime type not supported, don't upload
        //                    //    TempData["artworkUploadFail"] = true;
        //                    //}
        //                }
        //            }

        //        }

        //    }

        //    //All done - lets redirect to the current page & show our thanks/success message
        //    return RedirectToCurrentUmbracoPage();
        //}

        //private bool IsImage(HttpPostedFileBase file)
        //{
        //    string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

        //    return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        //}

        //private bool IsFile(HttpPostedFileBase file)
        //{
        //    string[] formats = new string[] { ".pdf", ".psd", ".ai" };

        //    return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        //}
    }
}