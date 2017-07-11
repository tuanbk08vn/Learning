using News.ViewModel;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;

namespace News.Controller
{
    public class LoginController : SurfaceController
    {
        // GET: Login
        public ActionResult Index()
        {
            try
            {
                return PartialView("_LoginPartial", new LoginViewModel());
            }
            catch (Exception e)
            {
                return Redirect("/home");
                throw;
            }

        }

        public ActionResult MemberLogout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/home");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        return this.Redirect("/home");
                    }
                    else
                    {
                        TempData["error-password"] = "Wrong Password or Username!!!!";
                        return CurrentUmbracoPage();
                    }
                }
                catch (System.Exception)
                {
                    TempData["error-password"] = "Wrong Password or Username!!!!";
                    return CurrentUmbracoPage();
                    throw;
                }

            }

            return CurrentUmbracoPage();
        }
    }
}