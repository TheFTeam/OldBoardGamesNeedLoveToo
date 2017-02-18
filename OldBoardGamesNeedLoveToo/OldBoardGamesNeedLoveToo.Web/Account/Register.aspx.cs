using System;
using System.Linq;
using System.Web;
using System.Web.UI;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Ninject;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Web.Models;
using System.IO;

namespace OldBoardGamesNeedLoveToo.Web.Account
{
    public partial class Register : Page
    {
        private byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int) imageFileLength);
            return imageData;
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            string defaultProfilePicLocation = Server.MapPath("~\\Content\\images\\Superman-profile-pic.svg.png");
            if (result.Succeeded)
            {
                var currentUser = manager.FindByName(user.UserName);
                var roleResult = manager.AddToRole(currentUser.Id, (UserRoleType.User).ToString());

                var newUserCustomInfo = new UserCustomInfo()
                {
                    Username = currentUser.UserName,
                    Email = currentUser.Email,
                    ApplicationUserId = currentUser.Id,
                    ProfilePricture = this.ReadImageFile(defaultProfilePicLocation)
                };

                currentUser.UserCustomInfo = newUserCustomInfo;
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