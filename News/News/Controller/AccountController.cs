using System;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace News.ViewModel
{
    public class AccountController : SurfaceController
    {
        // GET: Account
        public ActionResult Index()
        {
            var member = Members.GetCurrentMember();
            if (member != null)
            {
                try
                {
                    RegisterViewModel memberModel = new RegisterViewModel();

                    memberModel.FirstName = member.GetPropertyValue<string>("firstName");
                    memberModel.LastName = member.GetPropertyValue<string>("lastName");
                    memberModel.UserName = member.GetPropertyValue<string>("username");
                    memberModel.Password = member.GetPropertyValue<string>("password");
                    memberModel.Phone = member.GetPropertyValue<string>("phone");
                    memberModel.Address = member.GetPropertyValue<string>("address");
                    memberModel.Email = member.GetPropertyValue<string>("email");
                    memberModel.DOB = member.GetPropertyValue<DateTime>("dOB");

                    return PartialView("_EditPartial", memberModel);
                }
                catch (Exception e)
                {
                    return CurrentUmbracoPage();
                    throw;
                }
            }
            return CurrentUmbracoPage();

        }

        [HttpPost]
        public ActionResult Edit(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var memberService = Services.MemberService;
                    var member = memberService.GetById(Members.GetCurrentMemberId());
                    //var member = new Umbraco.Web.Security.MembershipHelper(Umbraco.Web.UmbracoContext.Current);
                    //var xx = Membership.GetUser(member);

                    //MemberProfile mp = ((MemberProfile)HttpContext.Current.Profile);
                    //var authorId = Model.Content.GetPropertyValue<int>("postAuthor", 0);
                    //var ms = Current.Services.MemberService;
                    //var member = ms.GetById(authorId);
                    //member.SetValue("postCounter", member.GetValue("postCounter"));
                    if (member != null)
                    {
                        //var profileModel = Members.GetCurrentMemberProfileModel();
                        //var profile = ProfileBase.Create(profileModel.UserName);
                        //var profile = (MemberProfile)HttpContext.Current.Profile;
                        //profile.SetPropertyValue("firstName", model.FirstName);
                        //profile.SetPropertyValue("lastName", model.LastName);
                        //profile.SetPropertyValue("dOB", model.DOB);
                        //profile.SetPropertyValue("phone", model.Phone);
                        //profile.SetPropertyValue("address", model.Address);
                        //profile.SetPropertyValue("email", model.Email);

                        //profile.Save();
                        member.Name = model.FirstName + ' ' + model.LastName;
                        member.Email = model.Email;
                        member.SetValue("firstName", model.FirstName);
                        member.SetValue("lastName", model.LastName);
                        member.SetValue("dOB", model.DOB);
                        member.SetValue("phone", model.Phone);
                        member.SetValue("address", model.Address);
                        member.SetValue("email", model.Email);

                        memberService.Save(member, true);
                        TempData["Message"] = "Successfully!";
                        return this.Redirect("/home");
                        //var memberService = Services.MemberService;
                        //var member = memberService.GetById(Members.GetCurrentMemberId());
                        //if (member != null)
                        //{
                        //    //member.SetValue("name", model.LastName);
                        //    member.SetValue("firstName", model.FirstName);
                        //    member.SetValue("lastName", model.LastName);
                        //    member.SetValue("username", model.UserName);
                        //    member.SetValue("dOB", model.DOB);
                        //    member.SetValue("phone", model.Phone);
                        //    member.SetValue("address", model.Address);
                        //    member.SetValue("email", model.Email);


                        //    memberService.Save(member);

                        //    //memberService.SavePassword(member, model.Password);

                        //    memberService.AssignRole(member.Id, "Member");

                        //    TempData["Message"] = "Register Successfully!";
                        //    return this.Redirect("/home");
                    }

                }
                catch (Exception e)
                {
                    return JavaScript("<script>alert(\"Unsucessfully!\")</script>");
                    throw;
                }

            }
            return JavaScript("<script>alert(\"Unsucessfully!\")</script>");
        }
    }
}