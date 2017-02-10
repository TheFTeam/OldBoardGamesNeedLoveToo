using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using OldBoardGamesNeedLoveToo.Web.Models;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using Ninject;
using OldBoardGamesNeedLoveToo.Services;
using OldBoardGamesNeedLoveToo.Web.App_Start;
using Microsoft.AspNet.Identity.EntityFramework;
using OldBoardGamesNeedLoveToo.Data;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;

namespace OldBoardGamesNeedLoveToo.Web.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            ObgnltContext db = new ObgnltContext();
            IRepository<UserCustomInfo> userCustomInfoRepo = new EfRepository<UserCustomInfo>(db);
            IUnitOfWork unitOfWork = new UnitOfWork(db);
            UserService userService = new UserService(userCustomInfoRepo, unitOfWork);
            //UserService userService = NinjectWebCommon.Kernel.Get<UserService>();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                var currentUser = manager.FindByName(user.UserName);
                var roleResult = manager.AddToRole(currentUser.Id, (UserRoleType.User).ToString());

                var newUserCustomInfo = new UserCustomInfo()
                {
                    Username = currentUser.UserName,
                    ApplicationUserId = currentUser.Id
                };
                userCustomInfoRepo.Add(newUserCustomInfo);
                unitOfWork.Commit();

                currentUser.UserCustomInfoId = newUserCustomInfo.Id;
                manager.Update(currentUser);

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}