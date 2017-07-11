using News.ViewModel;
using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace News.Controller
{
    public class ContactUsController : SurfaceController
    {
        // GET: ContactUs
        public ActionResult Index()
        {

            return PartialView("_ContactUsPartial", new ContactUsViewModel());
        }
        [HttpPost]
        public ActionResult ContactUsSubmit(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newContact = Services.ContentService.CreateContent(model.Name + '-' + model.Email, CurrentPage.Id, "ContactUs");
                    newContact.SetValue("fullName", model.Name);
                    newContact.SetValue("address", model.Address);
                    newContact.SetValue("email", model.Email);
                    newContact.SetValue("phone", model.Phone);
                    newContact.SetValue("note", model.Note);
                    Services.ContentService.SaveAndPublishWithStatus(newContact);
                    TempData["ContactUs"] = "Successfully!";
                    return this.Redirect("/home");
                }
                catch (Exception e)
                {
                    return JavaScript("<script>alert(\"Unsucessfully!\")</script>");
                    throw;
                }
            }
            return JavaScript("<script>alert(\"Unsucessfully!\")</script>");
            //ContactUsViewModel contactUsViewModel = new ContactUsViewModel(model);
            //if (Request.HttpMethod == "POST")
            //{
            //    var name = Request["Name"];
            //    var newContact =
            //        Services.ContentService.CreateContent(contactUsViewModel.Name, CurrentPage.Id, "ContactUs");
            //    newContact.SetValue("fullName", contactUsViewModel.Name);
            //    newContact.SetValue("address", contactUsViewModel.Address);
            //    newContact.SetValue("email", contactUsViewModel.Email);
            //    newContact.SetValue("phone", contactUsViewModel.Phone);
            //    newContact.SetValue("note", contactUsViewModel.Note);
            //    Services.ContentService.Save(newContact);
            //}
            //return CurrentTemplate(contactUsViewModel);
        }

    }
}