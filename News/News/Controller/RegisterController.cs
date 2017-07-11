using News.ViewModel;
using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace News.Controller
{
    public class RegisterController : SurfaceController
    {
        // GET: Register
        public ActionResult Index()
        {
            return PartialView("_RegisterPartial", new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var memberService = Services.MemberService;

                    if (memberService.GetByUsername(model.UserName) != null)
                    {
                        ModelState.AddModelError("", "Member already exists. Aborting!!!");
                        ViewBag.error = TempData["error"];
                        return CurrentUmbracoPage();
                    }

                    var member = memberService.CreateMember(model.UserName, model.Email, model.FirstName, "Member");
                    member.SetValue("firstName", model.FirstName);
                    member.SetValue("lastName", model.LastName);
                    member.SetValue("username", model.UserName);
                    member.SetValue("dOB", model.DOB);
                    member.SetValue("phone", model.Phone);
                    member.SetValue("address", model.Address);
                    member.SetValue("email", model.Email);

                    member.IsApproved = true;

                    memberService.Save(member);

                    memberService.SavePassword(member, model.Password);

                    memberService.AssignRole(member.Id, "Member");

                    TempData["Register"] = "Successfully!";
                    return this.Redirect("/home");
                }
                catch (Exception e)
                {
                    TempData["Register"] = "Uncessfully!!!";
                    return CurrentUmbracoPage();
                    throw;
                }

            }
            return JavaScript("<script>alert(\"Unsucessfully!\")</script>");
        }
    }
}